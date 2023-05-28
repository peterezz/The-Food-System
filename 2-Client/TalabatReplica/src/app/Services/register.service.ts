import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Register } from '../Models/register.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterModelService {

  private BaseUrl:string="https://localhost:44318/Register";
  
  constructor(private httpClient:  HttpClient ) {}
  
  Register(UserData:Register)
  {
    return this.httpClient.post(this.BaseUrl,UserData)
  };
}
