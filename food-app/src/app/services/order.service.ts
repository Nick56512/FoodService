import { Injectable, ɵclearResolutionOfComponentResourcesQueue } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../models/order';
import { Cart, CartLine } from '../models/cart';
@Injectable({
  providedIn: 'root'
})
export class OrderService {

  baseUrl:string
  constructor(private httpClient:HttpClient) {
    this.baseUrl="https://localhost:7147/api/order"
  }

  createOrder(order:Order,cart:Cart):Observable<any>
  {
     let json=  JSON.stringify(
      {
         order:order,
         orderItems:cart.cartLines.map(x=>{
           return {
             quantity:x.quantity,
             foodId:x.food.id
           }
         })
      })
      console.log(json)
      return this.httpClient.post(this.baseUrl,json,
      {
        headers:new HttpHeaders({
          'Content-Type':'application/json'
        })
      })
  }

}
