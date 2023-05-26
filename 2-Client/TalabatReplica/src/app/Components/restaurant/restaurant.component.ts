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
  alldishes:any[]=[];
      constructor(public service:CategoryService  , myRoute: ActivatedRoute){

      }
  ngOnInit(): void {


    this.service.GetAllCategories().subscribe({
      next:(data)=>{
        this.categories = data;
        console.log(this.items)
      }
    })

    this.service.GetAllDises().subscribe({
      next:(data:any)=>{
         this.alldishes = data;
         console.log(this.alldishes)
      }
    })



  }

  filterbycat(catname:any){
   let value = catname.target.value
    console.log(value)
if(value=="All"){
  this.service.GetAllDises().subscribe({
    next:(data:any)=>{
       this.alldishes = data;
       console.log(this.alldishes)
    }
  })
}else
   
    this.service.GetCategoryByName(value).subscribe({
      next:(data:any)=>{
        console.log(data);
        this.alldishes=data;
      }
    });

  }




}
