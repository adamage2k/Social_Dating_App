import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Member } from './models/member';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

const httpOpitons = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token,
  }),
};

@Injectable({
  providedIn: 'root',
})
export class MembersService {
  baseUrl = environment.apiUrl;
  members: Member[] = [];

  constructor(private http: HttpClient) {}

  getMembers() {
    return this.http.get<Member[]>(this.baseUrl + 'User/GetAll').pipe(
      map((members) => {
        this.members = members;
        return members;
      })
    );
  }

  addMatch(username: string) {
    return this.http.post(
      this.baseUrl + 'User/AddMatch/' + username,
      httpOpitons
    );
  }

  getMatches() {
    return this.http.get<Member[]>(this.baseUrl + 'User/GetMatches');
  }

  getMember(username: string) {
    return this.http.get<Member>(this.baseUrl + 'User/GetUser/' + username);
  }

  getSelfProfile() {
    return this.http.get<Member>(this.baseUrl + 'User/GetSelf');
  }

  updateMember(member: Member) {
    return this.http.put(this.baseUrl + 'Account/Update', member).pipe(
      map(() => {
        const index = this.members.indexOf(member);
        this.members[index] = member;
      })
    );
  }
}
