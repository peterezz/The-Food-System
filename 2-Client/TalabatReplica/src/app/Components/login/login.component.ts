import { Component, OnDestroy,  } from '@angular/core';
import { FormControl,FormGroup,Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Login } from 'src/app/Models/login.model';
import { LoginService } from 'src/app/Services/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  implements OnDestroy{

  in_or_up :any;

  SubscribeService : Subscription = new Subscription();

  email:string="";
  password:string="";
 
  //set validation
  loginEmailFormGroup  = new FormGroup({
    UserEmailAddress: new FormControl('', [
      Validators.required,
      Validators.email,
    ]),
    Password: new FormControl('', [
      Validators.required,
    ]),
  });

  //inject services
  constructor(public userlog:LoginService,rout:ActivatedRoute){
    this.email=rout.snapshot.data['email']
  }

  //Click Action
  LoginAction()
  {

    if(this.loginEmailFormGroup.valid)
    {
      let loginData = new Login(
        this.loginEmailFormGroup.controls['UserEmailAddress'].value,
        this.loginEmailFormGroup.controls['Password'].value
      );
      this.SubscribeService=this.userlog.UserLogin(loginData).subscribe({
        next: () => {
          alert("Login Successfull")
        },
        error : (err:any) =>{
          alert(err.error)
        }
      })
    }

    // this.userlog.UserLogin()

  

  }
 
  
  login(){
    this.in_or_up  ="" ;
  }

  logup(){
    this.in_or_up  ="sign-up-mode" ;
  }


  //after apply services making unsubscribe "Destructor of class"
  ngOnDestroy(): void 
  {
    this.SubscribeService.unsubscribe();
  }

}
