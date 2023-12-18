import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { AllDepartmentComponent } from './all-department/all-department.component';
import { AllEmployeeComponent } from './all-employee/all-employee.component';
import { AddDepartmentComponent } from './add-department/add-department.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { HomePageComponent } from './home-page/home-page.component';


@NgModule({
  declarations: [
    AppComponent,
    AllDepartmentComponent,
    AllEmployeeComponent,
    AddDepartmentComponent,
    AddEmployeeComponent,
    NavbarComponent,
    HomePageComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule    

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
