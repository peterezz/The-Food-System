import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthServicesService } from 'src/app/Services/auth-services.service';
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

  constructor(public castservice:SideCartService , public auth:AuthServicesService, public router:Router){
  }

  ngOnInit(): void 
  {
    // throw new Error('Method not implemented.');
      this.castservice.gitcartitems()
       this.dishesInCart  = this.castservice.dishesInCart
     
  }


  minsAmount(item:any){
    this.castservice.minsAmount(item)
  }
  addAmount(item:any){
    this.castservice.addAmount(item)
  }
  quantatychange()
  {
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


  loc=localStorage.getItem('user');

  // ToggleFun()
  // {
  //      const chk = document.querySelector('#Toggle') as HTMLInputElement;
  //      if(localStorage.getItem('user')!=null)
  //      {
  //       chk.innerText='LogOut';
  //       localStorage.clear()
  //      }
  //      else
  //      {
  //       chk.innerText='Login/Registration';
  //      }
  // }

  logout()
  {
    // localStorage.clear()
    localStorage.setItem('user','null');
    localStorage.setItem('role','null');
    this.router.navigate(['/login'])


  }



}
