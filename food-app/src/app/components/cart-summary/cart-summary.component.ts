import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cart } from 'src/app/models/cart';

@Component({
  selector: 'app-cart-summary',
  templateUrl: './cart-summary.component.html',
  styleUrls: ['./cart-summary.component.css']
})
export class CartSummaryComponent implements OnInit {

  constructor(public cart:Cart,
              private router:Router) { }

  ngOnInit(): void {
  }
  OnDelete(id:number){
    this.cart.RemoveCartLine(id);
  }
  OnCreateOrder(){
    this.router.navigate(['/createOrder'])
  }

}
