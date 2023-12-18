import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllDepartmentComponent } from './all-department/all-department.component';
import { AllEmployeeComponent } from './all-employee/all-employee.component';
import { AddDepartmentComponent } from './add-department/add-department.component';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { HomePageComponent } from './home-page/home-page.component';




const routes: Routes = [
  {path:'depts',component:AllDepartmentComponent},
  {path:'emps',component:AllEmployeeComponent},
  {path:'depts/add',component:AddDepartmentComponent},
  {path:'emps/add',component:AddEmployeeComponent},
  {path:'',component:HomePageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
