import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Account } from 'src/app/models/account';
import { RegistrationModel } from 'src/app/models/view-models/registrationModel';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  account:Account=new Account('','','','','')
  registrationModel:RegistrationModel =new RegistrationModel(this.account,'','')
  isSend:boolean=false;

  constructor(private accountService:AccountService,
              private router:Router) { }

  ngOnInit(): void {
  }
  SendConfirmCode()
  {
      this.isSend=true
      this.accountService.GenerateConfirmCode(this.registrationModel)
      .subscribe(x=>{
        console.log(x)
      })
  }
  Registration()
  {
      this.router.navigate(['/foodList'])
      this.accountService.Registration(this.registrationModel.confirmCode)
      .subscribe(x=>{
        
          this.accountService.AddAccountToSessionStorage(x)
           location.reload()
        
      });
  }
}


