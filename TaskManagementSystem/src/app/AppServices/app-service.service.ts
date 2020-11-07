import { Injectable } from '@angular/core';
//Performs HTTP requests. 
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class AppServiceService {

  //creating object of HttpClient.
  constructor(public http: HttpClient) { }

  login(data){
    return this.http.post("https://localhost:44304/api/v1/login",data);
  }
  
}
