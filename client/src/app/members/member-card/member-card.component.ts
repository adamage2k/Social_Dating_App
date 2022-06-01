import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MembersService } from 'src/app/members.service';
import { Member } from 'src/app/models/member';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css'],
})
export class MemberCardComponent implements OnInit {
  @Input() member: Member;
  @Output() userLiked = new EventEmitter<string>();
  constructor(
    private memberService: MembersService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    console.log(this.member);
  }

  addMatch(member: Member) {
    console.log(member);
    this.memberService.addMatch(member.userName).subscribe(
      () => {
        this.toastr.success(`Match added: ${member.firstName} ${member.lastName}`);
        this.userLiked.emit(member.userName);
      },
      (error) => this.toastr.error('Something went wrong')
    );
  }
}
