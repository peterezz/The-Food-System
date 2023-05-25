import { Injectable } from '@angular/core';
import { EmailValidator } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class UserRegistrationService {

  constructor() { }
  userRegister(firstname:string,secondname:string,email:EmailValidator|any,password:string|Number){
console.log("sign up")
  }
}
