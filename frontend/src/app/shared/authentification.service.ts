import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthentificationService {

  constructor(private http:HttpClient, public jwtHelper: JwtHelperService) {}
  
  Login(username: string, password: string): Observable<any> {
    return this.http.post(`https://localhost:7093/Authentication/Login?login=${username}&password=${password}`, null);
  }

  isAuthenticated(): boolean{
    const token = sessionStorage.getItem('jwt');
    return token != null;
  }

  refreshToken() {
    const token = sessionStorage.getItem('jwt');
    return this.http.get("https://localhost:7093/Authentication/Refreshtoken?token="+token);
  }
}
