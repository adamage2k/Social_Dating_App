import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model: any = {};
  loggedIn: boolean = false;

  constructor(
    public accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  login() {
    this.accountService.logIn(this.model).subscribe(
      (response) => {
        this.router.navigateByUrl('/members'), console.log(response);
        this.loggedIn = true;
      },
      (error) => {
        console.log(error);
        this.toastr.error(error.error);
      }
    );
  }

  logout() {
    this.loggedIn = false;
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
