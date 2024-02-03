import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormCourseComponent } from './Course/form-course/form-course.component';

const routes: Routes = [
  {path:"form-course", component:FormCourseComponent},
  {path:"form-course/:name", component:FormCourseComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
