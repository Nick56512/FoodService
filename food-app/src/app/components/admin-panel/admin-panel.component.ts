import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cart } from 'src/app/models/cart';
import { Category } from 'src/app/models/category';
import { Food } from 'src/app/models/food';
import { AccountService } from 'src/app/services/account.service';
import { CategoryService } from 'src/app/services/category.service';
import { FoodService } from 'src/app/services/food.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  inProcess:boolean=false

  foods:Food[]=[]
  categories:Category[]=[]
  categoryId:number=0
  pageSize:number=8
  pageNumber:number=1
  foodLength:number=0

  constructor(private foodService:FoodService,
              private categoryService:CategoryService,
              private accountService:AccountService,
              private router:Router,
              private cart:Cart) { }

  OnChangeQuantityFoods()
  {
    this.foodService.GetQuantityFoodsInCategory(this.categoryId)
    .subscribe(x=>this.foodLength=x)
  }
  ngOnInit(): void 
  {
    let acc=this.accountService.GetAccountFromSession()
    if(acc!=undefined&&acc.roles.indexOf('Admin')!=-1){
      this.OnChangeQuantityFoods()
      this.inProcess=true
      this.categoryService.GetCategories()
        .subscribe(x=>{
          this.categories=x
          this.inProcess=false
        })
    }
    else this.router.navigate(['/login'])
     
      
  }
  LoadProducts(){
    this.inProcess=true
    this.foodService.GetProducts(this.categoryId,this.pageSize,this.pageNumber)
      .subscribe(x=>{
          this.foods=x
          this.inProcess=false
      })
  }
  OnChangeCategory(event:any)
  {
      this.categoryId=event.target.value
      this.OnChangeQuantityFoods()
      this.LoadProducts()
  }
  OnPageChanged(page:any)
  {
      this.pageNumber=page
      this.LoadProducts()
  }
  OnDelete(id:number)
  {
      this.inProcess=true
      this.foodService.Delete(id)
      .subscribe(x=>{
          let index=this.foods.findIndex(x=>x.id==id)
          this.foods.splice(index,1)
          this.foodLength--
          this.cart.RemoveCartLine(id)
          this.inProcess=false
      })
  }

}
