import { Component, Input, OnInit } from '@angular/core';
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

  constructor(
    private memberService: MembersService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    console.log(this.member);
  }

  addMatch(member: Member) {
    this.memberService.addMatch(member.username).subscribe(
      () => this.toastr.success('Match added + member.knowsAs'),
      (error) => this.toastr.error('Something went wrong')
    );
  }
}
