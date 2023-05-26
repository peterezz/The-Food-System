import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../Models/login.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private BaseUrl:string="https://localhost:7065/Login";

  constructor(private httpClient:  HttpClient )
   {

   }
  
   UserLogin(UserData:Login)
   {
     return this.httpClient.post(this.BaseUrl,UserData)
   };

}
