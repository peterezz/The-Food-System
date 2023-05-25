import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Restaurant } from '../Models/restaurant.model';

@Injectable({
  providedIn: 'root'
})
export class RestuarantService {
 private BaseURL:string = "https://localhost:7065/Restaurants"
  constructor(private httpClient:HttpClient) { }
  AddRestaurant(restaurant: Restaurant)
  {
    return this.httpClient.post(this.BaseURL,restaurant);
  }
}
