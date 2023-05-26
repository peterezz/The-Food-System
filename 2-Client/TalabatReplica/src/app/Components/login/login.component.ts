import { Component, Input, OnInit } from '@angular/core';
import { EmailValidator } from '@angular/forms';
import { LoginModule } from 'src/app/Models/login/login.module';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  in_or_up :any;

  @Input() UserData:any;
  Email:string="";
  password:string="";
 
  // constructor(public userlog:LoginService , private data:LoginModule){}

  ngOnInit(): void
  {
    // this.data.Email=this.UserData.Email
    // this.data.Password=this.UserData.password;
  }

  // LoginAction()
  // {
  
  //   this.userlog.UserLogin({Email:this.data.Email,Password:this.data.Password}).subscribe({
  //     next : () => {
  //       alert('Login successfully')
  //     }
  //   })
  // }
 
  
  login(){
    this.in_or_up  ="" ;
  }

  logup(){
    this.in_or_up  ="sign-up-mode" ;
  }




}
