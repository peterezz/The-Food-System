import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from 'src/app/Services/category.service';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {
  name:any;
  categories:any;
  items:any;
      constructor(public service:CategoryService, myRoute: ActivatedRoute){

      }
  ngOnInit(): void {
    this.service.GetAllCategories().subscribe({
      next:(data)=>{
        this.categories = data;
        console.log(data);
      }
    })

  }




}
