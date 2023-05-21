import { Component, OnInit } from '@angular/core';
import { PaymentService } from '../payment.service';

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.css']
})
export class ConfirmationComponent implements OnInit{
  [x: string]: any;
  transactonId :any;
  constructor(private payment:PaymentService){

  }
  ngOnInit(): void {
   this.transactonId = this.payment['transactinID'] ;
  }
}
