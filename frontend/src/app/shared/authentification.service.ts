import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthentificationService {

  constructor(private http:HttpClient) {}
  
    Login(username:String, password:string):Observable<any>{
      return this.http.post(`https://localhost:7093/Authentification/Login?password=${password}&login=${username}`, null)

    }
   
}
