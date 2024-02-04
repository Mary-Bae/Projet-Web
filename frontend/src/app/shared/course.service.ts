import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CourseModel } from './course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private http: HttpClient) { }

  Get()
  {
    return this.http.get<Array<CourseModel>>("https://localhost:7093/Course");

  }

  GetByName(name: string)
  {
    return this.http.get<CourseModel>("https://localhost:7093/Course/ByName?name=" + name);

  }

  Post(course: CourseModel)
  {
    return this.http.post("https://localhost:7093/Course", course).subscribe();

  }
}
