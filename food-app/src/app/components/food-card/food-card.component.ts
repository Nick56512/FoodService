import { Component, Input, OnInit } from '@angular/core';
import { Cart } from 'src/app/models/cart';
import { Food } from 'src/app/models/food';

@Component({
  selector: 'app-food-card',
  templateUrl: './food-card.component.html',
  styleUrls: ['./food-card.component.css']
})
export class FoodCardComponent implements OnInit {

  @Input() food?:Food
  quantity:number=0
  inCart:boolean=false
  constructor(private cart:Cart) { }

  ngOnInit(): void 
  {
      let cartLine=this.cart.cartLines.find(x=>x.food.id==this.food?.id)
      if(cartLine!=undefined){
        this.inCart=true
        this.quantity=cartLine.quantity
      }
  }
  
  AddToCart(){
    if(this.food!=undefined){
      this.cart.AddCartLine(1,this.food);
      this.quantity++
      this.inCart=true;
    }
  }
  DeleteOneItemInCart(){
   if(this.food!=undefined&&this.quantity!=0){
      if(this.quantity==1){
        this.quantity=0
        this.cart.RemoveCartLine(this.food.id)
        this.inCart=false
      }
      else{
        this.cart.DeleteOneItem(this.food.id)
        this.quantity--
      }
    }
  }
  
}
