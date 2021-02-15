import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({ //this service can be injected into other components or other services in our application
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';

  //inject the HTTP client into our account service
  constructor(private http: HttpClient) { 

  }
  //receive the credentials from the login form from navbar
  login(model: any){
      return this.http.post(this.baseUrl + 'account/login', model);
  }
}
