import { Component, OnInit } from '@angular/core';
import { SideCartService } from 'src/app/Services/side-cart.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  dishesInCart:any[] =[];
  totalPrice:any;
  total:any=0;
  quantaty:any;
  pricequentity:any;
  ngOnInit(): void {
    // throw new Error('Method not implemented.');
      this.castservice.gitcartitems()
       this.dishesInCart  = this.castservice.dishesInCart
  }
  constructor(public castservice:SideCartService){
  }

  minsAmount(item:any){
    this.castservice.minsAmount(item)
  }
  addAmount(item:any){
    this.castservice.addAmount(item)
  }
  quantatychange(){
    this.castservice.quantatychange();
  }


  hidde="hidde";
  visabl:any;
  hidden(){
    this.hidde="hidde";
  }

  visable(){
    this.hidde="";
  }






}
