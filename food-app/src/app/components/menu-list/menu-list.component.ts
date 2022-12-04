import { Component, OnInit } from '@angular/core';
import { NgbNav } from '@ng-bootstrap/ng-bootstrap';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';
import { FoodListComponent } from '../food-list/food-list.component';

@Component({
  selector: 'app-menu-list',
  templateUrl: './menu-list.component.html',
  styleUrls: ['./menu-list.component.css']
})
export class MenuListComponent implements OnInit {

  categories?:Category[]
  constructor(private categoryService:CategoryService) { }

  ngOnInit(): void {
    this.categoryService.GetCategories()
    .subscribe(x=>{
        this.categories=x;
    })
  }
 

}
