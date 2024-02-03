import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CourseModel } from './course.model';
import { CourseService } from './course.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-course-form',
  templateUrl: './form-course.component.html',
  styleUrls: ['./form-course.component.css']
})
export class FormCourseComponent {
model: CourseModel;
formCourse: FormGroup;

constructor(private courseService:CourseService, private route: ActivatedRoute){

  this.formCourse = new FormGroup({
    name: new FormControl('', Validators.required),
    level: new FormControl('', Validators.required),
    schedule: new FormControl('', Validators.required),
    teacher: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required)
  });

  this.route.params.subscribe(params=>{
    let name = params['name']

    if(name){
      this.courseService.GetByName(name).subscribe(course=>{

        if (course){

          this.formCourse.controls['name'].setValue(course.name);
          this.formCourse.controls['level'].setValue(course.level);
          this.formCourse.controls['schedule'].setValue(course.schedule);
          this.formCourse.controls['teacher'].setValue(course.teacher);
          this.formCourse.controls['description'].setValue(course.description);

        }
      })
    }
  })
}

save(form: FormGroup){
let model= new CourseModel();

model.name= form.value.name;
model.level= form.value.level;
model.schedule= form.value.schedule;
model.teacher= form.value.teacher;
model.description= form.value.description;

this.courseService.Post(model);
}
}

