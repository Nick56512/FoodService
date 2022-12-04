import { Component, Input, OnInit } from '@angular/core';
import { Food } from 'src/app/models/food';
import { FoodService } from 'src/app/services/food.service';

@Component({
  selector: 'app-food-list',
  templateUrl: './food-list.component.html',
  styleUrls:['./food-list.component.css']
})
export class FoodListComponent implements OnInit {

  foods?:Food[]
  @Input() categoryId:number=0
  pageSize:number=8
  pageNumber:number=1
  foodLength:number=0

  constructor(private foodService:FoodService) { }

  LoadFoods(){
    this.foodService.GetProducts(this.categoryId, this.pageSize,this.pageNumber)
    .subscribe(x=>{
      this.foods=x
    })
  }
  ngOnInit(): void {
      this.LoadFoods()
      this.foodService.GetQuantityFoodsInCategory(this.categoryId)
         .subscribe(x=>this.foodLength=x)
  }
  OnPageChanged(page:any){
      this.pageNumber=page
      this.LoadFoods();
  }
}
