import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http:HttpClient) { }

  private BaseUrl = "https://localhost:44318/api/Category";

  GetAllCategories(){
    return this.http.get('https://fakestoreapi.com/products/categories');
  }
  GetCategoryByName(name:any){
    return this.http.get('https://fakestoreapi.com/products/category/'+name);
  }
  GetAllDises(){
    return this.http.get('https://fakestoreapi.com/products');
  }

}

