import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Member } from 'src/app/models/member';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
  
})
export class MemberCardComponent implements OnInit {
  @Input() member: Member;

  constructor(private router: Router) { }

  ngOnInit(): void {
    console.log(this.member)
  }

  onButtonClick(username: string) {
    console.log(username)
    this.router.navigate(['/members', username]);
  }

}
