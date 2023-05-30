import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Register } from '../Models/register.model';
import { AssigneRole } from '../Models/assigne-role.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterModelService {

  private BaseUrl:string="https://localhost:44318/Register";

  private BaseUrl1:string="https://localhost:44318/AssignRole";

  constructor(private httpClient:  HttpClient ) {}
  
  Register(UserData:Register)
  {
    return this.httpClient.post(this.BaseUrl,UserData)
  };

  AsigneRole(RoleData:AssigneRole)
  {
    return this.httpClient.post(this.BaseUrl1,RoleData)
  }

}
