import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from 'src/app/Services/category.service';

@Component({
  selector: 'app-category-items',
  templateUrl: './category-items.component.html',
  styleUrls: ['./category-items.component.css']
})
export class CategoryItemsComponent  implements OnInit {
  name:any;
  data:any;
  categories:any;
  constructor(public service : CategoryService, myRoute : ActivatedRoute){
    this.name = myRoute.snapshot.params["name"];
    console.log(this.name);


  }

  // gitproductbyname(namee:any){
  // console.log("clicked")
  // console.log(namee.name)
  //   this.service.GetCategoryByName(namee.name).subscribe({
  //     next:(data)=>{
  //      this.data = data;
  //       console.log(this.name);
  //     }
  //   });
  
  // }
  ngOnInit(): void {

    this.service.GetAllCategories().subscribe({
      next:(data)=>{
        this.categories = data;
        console.log(data);
      }
    })


  
  
        // this.service.GetCategoryByName(this.name).subscribe({
        //   next:(data)=>{
        //    this.name = data;
        //     console.log(this.name);
        //   }
        // });

}
  }

