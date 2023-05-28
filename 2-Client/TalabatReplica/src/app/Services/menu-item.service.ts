import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MenuItemService {
  

  constructor(private http:HttpClient) { }
  private BaseUrl ="https://localhost:44318/api/MenueItem"

  GetAllMenuItem(){
    return this.http.get(this.BaseUrl);
  }
  GetItemById(id:any){
    return this.http.get(this.BaseUrl+"/"+id);
  }
  Additem(items:any){
    return this.http.post(this.BaseUrl,items)
  }
  updateItem(item:any,id:any){
    return this.http.put(this.BaseUrl+"/"+id,item);
  }
  Delete(id:any){
    return this.http.delete(this.BaseUrl+"/"+id);
  }
}
