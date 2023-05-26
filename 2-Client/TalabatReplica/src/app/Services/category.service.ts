import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http:HttpClient) { }

<<<<<<< HEAD
  private BaseUrl = "https://localhost:7065/api/Category";
=======
  private BaseUrl = "https://fakestoreapi.com";
>>>>>>> 86a0f463a37349b35dac859e3fcfa3ec3bd4c85c

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

