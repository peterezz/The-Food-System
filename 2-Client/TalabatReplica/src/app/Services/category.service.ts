import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http:HttpClient) { }

  private BaseUrl = "https://localhost:7065/api/Category";

  GetAllCategories(){
    return this.http.get(this.BaseUrl);
  }
  GetCategoryByName(name:any){
    return this.http.get(`${this.BaseUrl}/${name}`);
  }

}

