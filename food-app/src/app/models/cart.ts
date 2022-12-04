import { JsonpClientBackend } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Food } from "./food";

export class CartLine{
    constructor(public quantity:number,public food:Food){}
}
@Injectable()
export class Cart{
    cartLines:CartLine[]=[]
    totalCost:number=0

    constructor(){
        const json=sessionStorage.getItem('cart')
        if(json!=undefined){
             const cart=JSON.parse(json)
             if(cart!=undefined){
                 this.cartLines=cart.cartLines,
                 this.totalCost=cart.totalCost
              }
        }
    }

    AddCartLine(quantity:number,food:Food){

        let line=this.cartLines?.find(l=>l.food.id==food.id)
        if(line!=undefined){
            line.quantity+=quantity
        }
        else{
            this.cartLines?.push(new CartLine(quantity,food))
        }
        this.Recalculate();
    }
    RemoveCartLine(foodId:number)
    {
        let index=this.cartLines?.findIndex(x=>x.food.id==foodId)
        if(index!=undefined)
        {
            this.cartLines?.splice(index,1)
            this.Recalculate()
        }  
    }
    Recalculate(){
        this.totalCost = 0; 
        this.cartLines?.forEach(l => { 
          this.totalCost += (l.quantity * l.food.price); 
        })
        this.totalCost=Number(this.totalCost.toFixed(2));
        this.Save();
    }
    Clear(){
        this.cartLines=[]
        this.totalCost=0
        this.Save();
    }
    Save(){
        sessionStorage.setItem('cart',JSON.stringify(
            {
                cartLines:this.cartLines,
                totalCost:this.totalCost
            }
            ));
    }
    DeleteOneItem(id:number)
    {
        let line=this.cartLines?.find(l=>l.food.id==id)
        if(line!=undefined){
            line.quantity-=1
            this.Recalculate()
        }
    }
    AllCount(){
        let all=0
        this.cartLines.forEach(x=>{
            all+=x.quantity
        })
        return all
    }
   
}