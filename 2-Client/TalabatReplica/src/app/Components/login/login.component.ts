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

  // {{in_or_up}}
  // const sign_in_btn: HTMLElement | null = document.querySelector("#sign-in-btn");
  // const sign_up_btn: HTMLElement | null = document.querySelector("#sign-up-btn");
  // const container: HTMLElement | null = document.querySelector(".container");

  // sign_up_btn?.addEventListener("click", () => {
  //   container?.classList.add("sign-up-mode");
  // });

  // sign_in_btn?.addEventListener("click", () => {
  //   container?.classList.remove("sign-up-mode");
  // });


}
