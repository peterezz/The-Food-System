import { Component, OnDestroy,  } from '@angular/core';
import { FormControl,FormGroup,Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Login } from 'src/app/Models/login.model';
import { Register } from 'src/app/Models/register.model';
import { LoginService } from 'src/app/Services/login.service';
import { RegisterModelService } from 'src/app/Services/register.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  implements OnDestroy{

  in_or_up :any;

  SubscribeService : Subscription = new Subscription();

//////////////////////////////////////////////////// LOGIN

  email:string="";
  password:string="";
  public errMss:string="";




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


  get inValidEmail() {
    return this.loginEmailFormGroup.controls.UserEmailAddress.invalid && (this.loginEmailFormGroup.controls.UserEmailAddress.dirty || this.loginEmailFormGroup.controls.UserEmailAddress.touched);
  }

  get inValidPassword(){
    return this.loginEmailFormGroup.controls.Password.invalid && (this.loginEmailFormGroup.controls.Password.dirty || this.loginEmailFormGroup.controls.Password.touched);

  }
  get foundErrorMessage()
  {
    return this.errMss
  }

  get checkinput(){
    return this.email!="";

  }

  //inject services
  constructor(public userlog:LoginService, public userreg:RegisterModelService  ,rout:ActivatedRoute, private router:Router){
  }

  //Click Action
  LoginAction()
  {

    if(!this.loginEmailFormGroup.valid)
    {
      alert("Some Data is missed, please Fill both Fields ")
    }

    if(this.loginEmailFormGroup.valid)
    {
      let loginData = new Login(
        this.loginEmailFormGroup.controls['UserEmailAddress'].value,
        this.loginEmailFormGroup.controls['Password'].value
      );
      this.SubscribeService=this.userlog.UserLogin(loginData).subscribe({
        next: () => {
          alert("Login Successfull")
          this.router.navigate(['/AllResturants'])

        },
        error : (err:any) =>{
          alert(err.error)
        }
      })
    }
  }


  ////////////////////////////////////// REGISTRE


    Password =new FormControl('', [
      Validators.required,
      Validators.pattern(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\d]{8,}$/),
    ]);


      //set validation
  registerEmailFormGroup  = new FormGroup({

    firstName: new FormControl('', [
      Validators.required,
      Validators.minLength(2)

    ]),
    lastName: new FormControl('', [
      Validators.minLength(3)

    ]),
     username: new FormControl('', [
      Validators.required,
      Validators.minLength(5)
    ]),

     EmailAddress: new FormControl('', [
      Validators.required,
      Validators.email,
    ]),
    Password: new FormControl('', [


    ]),
  });

  get validFirstName()
  {
    return this.registerEmailFormGroup.controls.firstName.invalid && (this.registerEmailFormGroup.controls.firstName.dirty || this.registerEmailFormGroup.controls.firstName.touched);
  }

  get validUserName()
  {
    return this.registerEmailFormGroup.controls.username.invalid && (this.registerEmailFormGroup.controls.username.dirty || this.registerEmailFormGroup.controls.username.touched);
  }

  get ValidEmail() {
    return this.registerEmailFormGroup.controls.EmailAddress.invalid && (this.registerEmailFormGroup.controls.EmailAddress.dirty || this.registerEmailFormGroup.controls.EmailAddress.touched);
  }

  get validPassword(){
    return this.registerEmailFormGroup.controls.Password.invalid && (this.registerEmailFormGroup.controls.Password.dirty || this.registerEmailFormGroup.controls.Password.touched);
  }

  RegisterAction(){

    if(!this.registerEmailFormGroup.valid)
    {
      alert("Some Required Data is missed, please Fill both Fields ")
    }

   else if(this.registerEmailFormGroup.valid)
    {
      let registerData = new Register(
        this.registerEmailFormGroup.controls['firstName'].value,
        this.registerEmailFormGroup.controls['lastName'].value,
        this.registerEmailFormGroup.controls['username'].value,
        this.registerEmailFormGroup.controls['EmailAddress'].value,
        this.registerEmailFormGroup.controls['Password'].value

      );
      this.SubscribeService=this.userreg.Register(registerData).subscribe({
        next: (data) => {
          alert("Registered Successfully" + data)
          this.router.navigate(['/AllResturants'])
        },
        error : (err:any) =>{
          alert(err.error)
        }
      })
    }
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
