import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormCourseComponent } from './Course/form-course/form-course.component';
import { TableCourseComponent } from './Course/table-course/table-course.component';

const routes: Routes = [
  {path:"form-course", component:FormCourseComponent},
  {path:"form-course/:name", component:FormCourseComponent},
  {path:"table-course", component:TableCourseComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
