import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Account } from '../models/account';
import { RegistrationModel } from '../models/view-models/registrationModel';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl:string
  constructor(private httpClient:HttpClient) 
  {
    this.baseUrl="https://localhost:7147/api/account"
  }
  GenerateConfirmCode(model:RegistrationModel):Observable<any>{
    let json=JSON.stringify(
    {
        name:model.account.name,
        lastname:model.account.lastname,
        email:model.account.email,
        numberPhone:model.account.numberPhone,
        password:model.password,
        confirmPassword:model.confirmPassword
    })
    return this.httpClient.post(`${this.baseUrl}/confirmCode`,json,
    {
      headers:new HttpHeaders({
        'Content-Type':'application/json'
      })
    }
    )
  }
  Registration(confirmCode:number):Observable<any>
  {
    return this.httpClient.post(`${this.baseUrl}/registration?confirmCode=${confirmCode}`,'')
  }
  AddAccountToSessionStorage(response:any)
  {
    console.log(response)
     let json=JSON.stringify(
     {
        name:response.name,
        lastname:response.lastname,
        email:response.email,
        numberPhone:response.numberPhone,
        roles:response.role
     })
     window.sessionStorage.setItem('token',response.access_token)
     window.sessionStorage.setItem('account',json)
  }
  Login(credentials:any):Observable<any>
  {
    return this.httpClient.post(`${this.baseUrl}/login`,
    JSON.stringify(credentials),
    {
      headers:new HttpHeaders({
        'Content-Type':'application/json'
      })
    })
  }
  GetAccountFromSession():any
  {
      let json=window.sessionStorage.getItem('account')
      if(json!=null){
        return JSON.parse(json)
      }
      return null
  }
  LogoutAccount(){
    window.sessionStorage.removeItem('token')
    window.sessionStorage.removeItem('account')
  }

  
}
