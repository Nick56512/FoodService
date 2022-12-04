import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm=this.formBuilder.group({
    email:'',
    password:''
  })
  constructor(private formBuilder:FormBuilder,
              private accountService:AccountService,
              private router:Router) { }

  ngOnInit(): void {
  }
  Login(){
  
    let credentials={
      email:this.loginForm.get('email')?.value,
      password:this.loginForm.get('password')?.value
    }
    this.accountService.Login(credentials)
    .subscribe(x=>{
      this.accountService.AddAccountToSessionStorage(x)
        location.reload()
     })
  }

}
