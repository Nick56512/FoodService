import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

    baseUrl:string
    constructor(private httpClient:HttpClient) {
      this.baseUrl="https://localhost:7147/api/category"
    }
    GetCategories():Observable<any>{
        return this.httpClient.get(`${this.baseUrl}`);
    }
}