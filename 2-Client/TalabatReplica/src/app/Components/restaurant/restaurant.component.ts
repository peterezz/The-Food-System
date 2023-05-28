import { Restaurant } from './../../Models/restaurant.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from 'src/app/Services/category.service';
import { RestuarantService } from 'src/app/Services/restuarant.service';

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
  dishesInCart:any[] = []
  quantity:number = 1 ;
  amountInput:any="#editEmployeeModal";
  ResID:any;
  Restaurant:any;
      constructor(public service:CategoryService  , myRoute: ActivatedRoute , public ResService:RestuarantService){
               this.ResID = myRoute.snapshot.params["restaurantID"];
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

    this.GetResByID(this.ResID);

  }

  GetResByID(id:any){
    this.ResService.GetRestuarantById(id).subscribe({
      next:(data)=>{this.Restaurant = data;}
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

  /////////////////////////////////////////// Add Dishes TO Cart
  amount(amount:any){
   this.quantity = amount.target.value;
  }
 save(){
   console.log(this.quantity)
  }
addtocart(data:any){
  if("cart" in localStorage){
  data.quantity = this.quantity ;
  console.log(data)
  this.dishesInCart= JSON.parse(localStorage.getItem("cart")!)
  let exist =
  this.dishesInCart.find(item => item.id == data.id)
  if(exist){
    alert("product is already in your cart")
  }else{
    alert(" Don ")
    this.dishesInCart.push(data)
    localStorage.setItem("cart",JSON.stringify(this.dishesInCart))
  }
}else{
  data.quantity = this.quantity ;
  console.log(data)
  this.dishesInCart.push(data)
  localStorage.setItem("cart",JSON.stringify(this.dishesInCart))
}
  }


}
