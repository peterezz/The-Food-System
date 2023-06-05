import { Component, OnInit } from '@angular/core';
import { AppOwnerServiceService } from 'src/app/Services/app-owner-service.service';

@Component({
  selector: 'app-app-owner',
  templateUrl: './app-owner.component.html',
  styleUrls: ['./app-owner.component.css']
})
export class AppOwnerComponent implements OnInit {
constructor( private myservice : AppOwnerServiceService){}

allresAdmins:any;
  ngOnInit(): void {

    this.myservice.GetAllResAdmins().subscribe({
      next:(data)=>{
         this.allresAdmins = data;
          console.log(this.allresAdmins)
      }
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


