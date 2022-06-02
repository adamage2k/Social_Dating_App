import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  registerForm: FormGroup;

  constructor(
    private accountService: AccountService,
    private toastr: ToastrService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.intitiForm();
  }

  intitiForm() {
    this.registerForm = this.fb.group({
      gender: ['male'],
      username: ['', Validators.required],
      age: ['', Validators.required],
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]]
    })
    this.registerForm.controls.password.valueChanges.subscribe(() => {
      this.registerForm.controls.confirmPassword.updateValueAndValidity();
    })
  }



  register() {
   this.model.username = this.registerForm.value.username;
   this.model.password = this.registerForm.value.password;
   this.model.firstName = this.registerForm.value.firstname;
   this.model.lastName = this.registerForm.value.lastname;
   this.model.age = this.registerForm.value.age;
    this.accountService.register(this.model).subscribe(
      (response) => {
        this.toastr.success("Correct registration!");
        this.cancel();
      },
      (error) => {
        this.toastr.error("Incorrect data");
      }
    );
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
