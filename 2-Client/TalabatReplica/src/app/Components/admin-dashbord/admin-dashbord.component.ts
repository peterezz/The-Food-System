
import { Component,  OnInit, Output  } from '@angular/core';
import { MenuItemService } from 'src/app/Services/menu-item.service';


@Component({
  selector: 'app-admin-dashbord',
  templateUrl: './admin-dashbord.component.html',
  styleUrls: ['./admin-dashbord.component.css'  ]

})

export class AdminDashbordComponent implements OnInit {
  items:any;
  constructor(public service:MenuItemService){}
  ngOnInit(): void {
    this.service.GetAllMenuItem().subscribe({
      next:(data)=>{this.items=data;console.log(data);},
      error:(err)=>{console.log(err)}
      
    })
  }
  Additem(name:any,price:any,photoFile:any,description:any,categoryName:any,size:any){
    
    this.service.Additem({name,price,photoFile,description,categoryName,size}).subscribe();
    
  
  }

// @Output () hidden="hidden"
}
