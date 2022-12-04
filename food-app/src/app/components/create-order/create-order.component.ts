import { Component, OnInit } from '@angular/core';
import { Cart } from 'src/app/models/cart';
import { Order } from 'src/app/models/order';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { OrderService } from 'src/app/services/order.service';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit {

  inProcess:boolean=false;
  order:Order=new Order('','','','','','')
  constructor(public cart:Cart,
              private orderService:OrderService,
              private router:Router,
              private accountService:AccountService) { }

  ngOnInit(): void 
  {
     this.inProcess=true;
     let acc=this.accountService.GetAccountFromSession()
     if(acc!=null){
       this.order.name=acc.name
       this.order.lastname=acc.lastname
       this.order.email=acc.email
       this.order.numberPhone=acc.numberPhone
     }
     this.inProcess=false;
  }
  CreateOrder()
  {
      this.inProcess=true;
      this.order.totalPrice=this.cart.totalCost
      this.orderService.createOrder(this.order,this.cart)
      .subscribe(x=>{
        this.cart.Clear();
        this.inProcess=false;
        this.router.navigate(['/foodList'])
      })
  }
}
