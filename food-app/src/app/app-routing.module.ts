import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddFoodComponent } from './components/add-food/add-food.component';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { CartSummaryComponent } from './components/cart-summary/cart-summary.component';
import { CreateOrderComponent } from './components/create-order/create-order.component';
import { FoodDetailsComponent } from './components/food-details/food-details.component';
import { LoginComponent } from './components/login/login.component';
import { MenuListComponent } from './components/menu-list/menu-list.component';
import { RegistrationComponent } from './components/registration/registration.component';

const routes: Routes = [
  {path:"foodList",component:MenuListComponent},
  {path:"cart",component:CartSummaryComponent},
  {path:"createOrder",component:CreateOrderComponent},
  {path:"registration",component:RegistrationComponent},
  {path:"login",component:LoginComponent},
  {path:"food/:id",component:FoodDetailsComponent},
  {path:"addfood",component:AddFoodComponent},
  {path:"adminpanel",component:AdminPanelComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
