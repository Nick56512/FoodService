import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cart } from 'src/app/models/cart';
import { Food } from 'src/app/models/food';
import { FoodService } from 'src/app/services/food.service';

@Component({
  selector: 'app-food-details',
  templateUrl: './food-details.component.html',
  styleUrls: ['./food-details.component.css']
})
export class FoodDetailsComponent implements OnInit {

  food?:Food
  quantity:number=0
  inCart:boolean=false

  constructor(private foodService:FoodService,
              private route:ActivatedRoute,
              private cart:Cart) { }

  ngOnInit(): void 
  {
      const id=Number(this.route.snapshot.paramMap.get('id'))
      if(id!=null){
         this.foodService.Get(id)
         .subscribe(x=>{
            this.food=x
            let cartLine=this.cart.cartLines.find(x=>x.food.id==id)
            if(cartLine!=undefined){
              this.inCart=true
               this.quantity=cartLine.quantity
            }
         })
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
