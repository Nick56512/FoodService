import { HttpClient, HttpHeaders } from '@angular/common/http';
import { toBase64String } from '@angular/compiler/src/output/source_map';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Food } from '../models/food';

@Injectable({
  providedIn: 'root'
})
export class FoodService {
  baseUrl:string
  constructor(private httpClient:HttpClient) {
    this.baseUrl="https://localhost:7147/api/food"
  }
  GetProducts(categoryId:number,
              pageSize:number,
              pageNumber:number,
              ):Observable<any>
  {
    return this.httpClient.get(`${this.baseUrl}/${categoryId}/${pageSize}/${pageNumber}`)
  }
  GetQuantityFoodsInCategory(categoryId:number):Observable<any>
  {
    return this.httpClient.get(`${this.baseUrl}/foodCount/${categoryId}`)
  }
  Get(id:number):Observable<any>
  {
      return this.httpClient.get(`${this.baseUrl}/details/${id}`)
  }
  Delete(id:number):Observable<any>
  {
    const token=window.sessionStorage.getItem('token')
      return this.httpClient.delete(`${this.baseUrl}/${id}`,{
        headers:new HttpHeaders({
          'Authorization':'bearer '+token
        })
      })
  }
  Add(food:Food):Observable<any>
  {
      const token=window.sessionStorage.getItem('token')
      return this.httpClient.post(this.baseUrl,JSON.stringify(food),
          {
            headers:new HttpHeaders({
              'Content-Type':'application/json',
              'Authorization':'bearer '+token
            })
          })
    
  }
}
