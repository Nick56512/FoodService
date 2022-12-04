import { Component, OnInit } from '@angular/core';
import { Account } from './models/account';
import { Cart } from './models/cart';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit{
  title = 'food-app';
  loginAccount?:Account

  constructor(public cart:Cart,
              private accountService:AccountService){}

  ngOnInit(): void 
  {
      this.loginAccount=this.accountService.GetAccountFromSession()  
  }
  Logout(){
    this.accountService.LogoutAccount()
    location.reload()
  }
  

}
