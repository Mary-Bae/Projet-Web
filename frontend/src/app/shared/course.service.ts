import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CourseModel } from './course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  
  constructor(private http: HttpClient) { }

  Get() //Le changement de la methode ici aura permis à arranger le problème d'authentification que j'avais. Le même changement a été fait pour GetByName.
        // Il faudra encore voir pour le Post
  {
    let token = localStorage.getItem('jwt');

    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      })
    };
    return this.http.get<Array<CourseModel>>("https://localhost:7093/Course", httpOptions)

  }

  GetByName(name: string)
  {
    let token = localStorage.getItem('jwt');

    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      })
    };
    return this.http.get<CourseModel>("https://localhost:7093/Course/ByName?name=" + name, httpOptions);

  }

  Post(course: CourseModel)
  {
    return this.http.post("https://localhost:7093/Course", course).subscribe();

  }
}
