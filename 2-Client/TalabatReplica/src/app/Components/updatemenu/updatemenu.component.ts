import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from 'src/app/Services/category.service';
import { MenuItemService } from 'src/app/Services/menu-item.service';

@Component({
  selector: 'app-updatemenu',
  templateUrl: './updatemenu.component.html',
  styleUrls: ['./updatemenu.component.css']
})
export class UpdatemenuComponent  {
  ID:any;
  itemdetails:any;
  Category:any;
  constructor(public service:MenuItemService,myRoute:ActivatedRoute,public CategorieService:CategoryService,public route:Router){
    this.ID = myRoute.snapshot.params["itemID"];
  }
  ngOnInit(): void {
    this.service.GetItemById(this.ID).subscribe({
      next:(data)=>{this.itemdetails=data;console.log(this.itemdetails)},
      error:(err)=>{console.log(err)}
    
      
    })
    this.GetAllCategories();
  }
  updateItem(itemID:any,name:any,price:any,description:any,size:any,resturantID:any,categoryID:any){
    console.log({itemID,name,price,description,size,resturantID,categoryID},+this.ID);
    this.service.updateItem({itemID,name,price,description,size,resturantID,categoryID},+this.ID).subscribe();
    this.route.navigateByUrl("/Adminmenu");
    
  }
  GetAllCategories(){
    this.CategorieService.GetAllCategories().subscribe({
      next:(data)=>{this.Category=data;console.log(data);},
      error:(err)=>{console.log(err)}
    })
  }
}
