import { Component, OnInit } from '@angular/core';
import { RestuarantService } from 'src/app/Services/restuarant.service';

@Component({
  selector: 'app-all-resturants',
  templateUrl: './all-resturants.component.html',
  styleUrls: ['./all-resturants.component.css']
})
export class AllResturantsComponent implements OnInit {
  constructor(public service : RestuarantService){}
  Restarunts :any ;
  ngOnInit(): void {
        this.service.GetAllRestuarants().subscribe({
          next:(data)=>{this.Restarunts=data;console.log(data);},
          error:(error)=>{console.log(error);}
        });
  }

}
