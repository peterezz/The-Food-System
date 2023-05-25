import { Component, OnInit } from '@angular/core';
import { UserRegistrationService } from 'src/app/Services/user-registration.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
constructor(private user : UserRegistrationService){}
  ngOnInit(): void {
    // this.user.userRegister(firstname:string,secondname:string,email:EmailValidator|any,password:string|Number);
  }

  in_or_up :any;
  login(){
    this.in_or_up  ="" ;
  }

  logup(){
    this.in_or_up  ="sign-up-mode" ;
  }




}
