import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  in_or_up :any;
  login(){
    this.in_or_up  ="" ;
  }

  logup(){
    this.in_or_up  ="sign-up-mode" ;
  }




}
