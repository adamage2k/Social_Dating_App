import { Component, OnInit } from '@angular/core';
import { MembersService } from '../members.service';
import { Member } from '../models/member';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css'],
})
export class ListsComponent implements OnInit {
  members: Partial<Member[]>;

  constructor(private memberService: MembersService) {}

  ngOnInit(): void {
    this.loadLikes();
  }

  loadLikes() {
    this.memberService.getMatches().subscribe((response) => {
      console.log(response)
      this.members = response;
    });
  }
}
