import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../models/user';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();
  loggedIn: boolean;

  constructor(private http: HttpClient) {}

  logIn(model: any) {
    return this.http.post(this.baseUrl + 'Account/Login', model).pipe(
      map((response: User) => {
        console.log(response);
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
          this.loggedIn = true;
        }
      })
    );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'Account/Register', model).pipe(
      map((user: User) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
          this.loggedIn = true;
        }
      })
    );
  }

  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }

  autoLogin() {
    let item = localStorage.getItem('user');

    if (item) {
      const user: User = JSON.parse(item);
      this.currentUserSource.next(user);
      this.loggedIn = true;
    }
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
    this.loggedIn = false;
  }
}
