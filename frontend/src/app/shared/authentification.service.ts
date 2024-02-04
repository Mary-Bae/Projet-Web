import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthentificationService {

  constructor(private http:HttpClient) {}
  
  Login(username: string, password: string): Observable<any> {
    return this.http.post(`https://localhost:7093/Authentication/Login?login=${username}&password=${password}`, null);
  }
}
