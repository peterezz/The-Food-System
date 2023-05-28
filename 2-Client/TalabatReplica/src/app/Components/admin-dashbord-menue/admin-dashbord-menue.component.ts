import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from 'src/app/Services/category.service';
import { MenuItemService } from 'src/app/Services/menu-item.service';

@Component({
  selector: 'app-admin-dashbord-menue',
  templateUrl: './admin-dashbord-menue.component.html',
  styleUrls: ['./admin-dashbord-menue.component.css']
})
export class AdminDashbordMenueComponent {
  items:any;
  Category:any;
  ID:any;
  itemdetails:any;
  constructor(public service:MenuItemService,public CategorieService:CategoryService,myRoute:ActivatedRoute){
    this.ID = myRoute.snapshot.params["itemID"];
  }
  ngOnInit(): void {
    this.service.GetAllMenuItem().subscribe({
      next:(data)=>{this.items=data;console.log(data);},
      error:(err)=>{console.log(err)}
      
    })
    this.GetItemByID(this.ID);
    this.GetAllCategories();
   
  }
  Additem (name:any,price:any,description:any,size:any,resturantID:any,categoryID:any){

    this.service.Additem({name,price,description,size,resturantID,categoryID}).subscribe(  )

  }
  updateItem(name:any,price:any,description:any,size:any,resturantID:any,categoryID:any){
    this.service.updateItem({name,price,description,size,resturantID,categoryID},this.ID).subscribe();
    
  }
  GetItemByID(id:any){
    this.service.GetItemById(id).subscribe({
      next:(data)=>{this.itemdetails=data},
      error:(err)=>{console.log(err)}
      
    })

  }
  Delete(id:any,row:any){
    this.service.Delete(id).subscribe();
    row.remove();
  }
  GetAllCategories(){
    this.CategorieService.GetAllCategories().subscribe({
      next:(data)=>{this.Category=data;console.log(data);},
      error:(err)=>{console.log(err)}
    })
  }

}
