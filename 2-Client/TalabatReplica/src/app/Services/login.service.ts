import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmailValidator } from '@angular/forms';
import { LoginModule } from '../Models/login/login.module';

@Injectable({
  providedIn: 'root'
})
export class LoginService {


  private BaseUrl:string="hhttps://localhost:44318/Login";

  constructor(private httpClient:  HttpClient  )
   {

   }
  
   UserLogin(UserData:LoginModule)
   {
     return this.httpClient.post(this.BaseUrl,{Email:UserData.Email, Pass:UserData.Password})
   }


}
