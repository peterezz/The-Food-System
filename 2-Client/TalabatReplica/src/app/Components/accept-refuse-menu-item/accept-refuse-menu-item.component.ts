import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MenuItemService } from 'src/app/Services/menu-item.service';

@Component({
  selector: 'app-accept-refuse-menu-item',
  templateUrl: './accept-refuse-menu-item.component.html',
  styleUrls: ['./accept-refuse-menu-item.component.css']
})
export class AcceptRefuseMenuItemComponent implements OnInit {
  id:any;
  menuItem:any;
constructor(private menuItemServices: MenuItemService, private rout:ActivatedRoute)
{
  this.id=rout.snapshot.params["id"];
  console.log(this.id)
}



  ngOnInit(): void {

    this.menuItemServices.GetItemById(this.id).subscribe({
      next:(data:any)=>{this.menuItem=data ;
      console.log(this.menuItem ) 
      this.myValidations.patchValue({
        name:this.menuItem.name ,
        description:this.menuItem.description 
      })},
      error:(err)=>{console.log(err.error) }
    })



  }

myValidations:FormGroup=new FormGroup({
  itItem :new FormControl(null),
  name:new FormControl(null),
  price:new FormControl(null),
  description:new FormControl(null),
  size:new FormControl(null),
  isAccepted:new FormControl(null),
  resturantID:new FormControl(null),
  Offer:new FormControl(null),
  CategoryID:new FormControl(null)
})

update()
{
this.menuItemServices.updateItem(this.myValidations,this.id,this.header)
}
header = new HttpHeaders({
  'Content-Type': 'multipart/form-data',
  'Accept': 'application/json'
 });

}
