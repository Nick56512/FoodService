import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule,ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FoodListComponent } from './components/food-list/food-list.component';
import {HttpClientModule} from '@angular/common/http'
import {NgbNavModule,NgbPaginationModule,NgbDropdownModule} from '@ng-bootstrap/ng-bootstrap';
import { MenuListComponent } from './components/menu-list/menu-list.component';
import { FoodCardComponent } from './components/food-card/food-card.component'
import { RouterModule } from '@angular/router';
import { Cart } from './models/cart';
import { CartSummaryComponent } from './components/cart-summary/cart-summary.component';
import { CreateOrderComponent } from './components/create-order/create-order.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { LoginComponent } from './components/login/login.component';
import { FoodDetailsComponent } from './components/food-details/food-details.component';
import { AddFoodComponent } from './components/add-food/add-food.component';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';


@NgModule({
  declarations: [
    AppComponent,
    FoodListComponent,
    MenuListComponent,
    FoodCardComponent,
    CartSummaryComponent,
    CreateOrderComponent,
    RegistrationComponent,
    LoginComponent,
    FoodDetailsComponent,
    AddFoodComponent,
    AdminPanelComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    NgbNavModule,
    NgbPaginationModule,
    NgbDropdownModule,
    FormsModule
  ],
  providers: [Cart],
  bootstrap: [AppComponent]
})
export class AppModule { }
