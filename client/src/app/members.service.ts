import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Member } from './models/member';

const httpOpitons = {
  headers: new HttpHeaders({ 
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
  })
}

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMembers() {
    return this.http.get<Member[]>(this.baseUrl + 'users', httpOpitons)
  }

  getMember(username: string) {
    return this.http.get<Member>(this.baseUrl + 'user/' + username, httpOpitons);
  }
}