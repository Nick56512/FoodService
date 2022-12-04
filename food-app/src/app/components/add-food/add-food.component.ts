import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/models/category';
import { Food } from 'src/app/models/food';
import { Subcategory } from 'src/app/models/subcategory';
import { AccountService } from 'src/app/services/account.service';
import { CategoryService } from 'src/app/services/category.service';
import { FoodService } from 'src/app/services/food.service';
import { SubcategoryService } from 'src/app/services/subcategory.service';

@Component({
  selector: 'app-add-food',
  templateUrl: './add-food.component.html',
  styleUrls: ['./add-food.component.css']
})
export class AddFoodComponent implements OnInit {

  inProcess:boolean=false
  food:Food=new Food('','','')
  categories:Category[]=[]
  subcategories:Subcategory[]=[]
  photoFile?:File

  constructor(private foodService:FoodService,
              private categoryService:CategoryService,
              private subcategoryService:SubcategoryService,
              private accountService:AccountService,
              private router:Router) { }

  ngOnInit(): void 
  {
    let acc=this.accountService.GetAccountFromSession()
    if(acc!=undefined&&acc.roles.indexOf('Admin')!=-1){
    this.inProcess=true
    this.categoryService.GetCategories()
        .subscribe(x=>
        {
          this.categories=x
          this.inProcess=false
        })
    }
    else this.router.navigate(['/login'])
  }
  private getBase64(){
    if(this.photoFile!=undefined){
    let reader = new FileReader();
    reader.readAsDataURL(this.photoFile);
    reader.onload = ()=>{
      this.food.photoBase64=String(reader.result)
      this.food.photoName=String(this.photoFile?.name)
    };
    reader.onerror = function (error) {
      console.log('Error: ', error);
    };
  }
  }
  changeFile(files:any)
  {
      this.photoFile=files.files.item(0)
      this.getBase64()
  }
  uploadSubcategories(){
    this.food.subcategoryId=undefined
    if(this.food.categoryId!=undefined)
    {
        this.subcategoryService.GetSubcategories(this.food.categoryId)
        .subscribe(x=>{
          this.subcategories=x
        })
    }
  }
  AddFood(){
    this.inProcess=true
    this.foodService.Add(this.food)
    .subscribe(x=>{
      this.inProcess=false
      this.router.navigate(['/adminpanel'])
    })
  }


}
