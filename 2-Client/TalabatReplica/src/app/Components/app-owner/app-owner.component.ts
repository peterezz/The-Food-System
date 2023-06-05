import { Component, OnInit } from '@angular/core';
import { AppOwnerServiceService } from 'src/app/Services/app-owner-service.service';
import { MenuItemService } from 'src/app/Services/menu-item.service';

@Component({
  selector: 'app-app-owner',
  templateUrl: './app-owner.component.html',
  styleUrls: ['./app-owner.component.css']
})
export class AppOwnerComponent implements OnInit {
constructor( private myservice : AppOwnerServiceService ,private menuitemService :MenuItemService){}

allresAdmins:any;
allMenauitems:any;
  ngOnInit(): void {

    this.myservice.GetAllResAdmins().subscribe({
      next:(data)=>{
         this.allresAdmins = data;
          console.log(this.allresAdmins)
      }
    });
      this.menuitemService.GetAllMenuItem().subscribe({
        next:(data:any)=>{this.allMenauitems=data;  
        console.log(data)
        },
         error:(err:any)=>{console.log(err.error)}
    })

  }
  Delete(id:any,row:any)
  {
    this.myservice.deleteResAdmin(id).subscribe({
      next:(data)=>{
        row.remove();
      }
    })
  }
allresAdmin:any;
}


