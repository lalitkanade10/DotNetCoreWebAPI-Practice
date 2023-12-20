import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import { AddEmployeeRequest } from './models/add-employee-request.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private basePath ='https://localhost:44313/api/Employee';
  public EmpIDGlo=0;


  constructor(private http:HttpClient) { }

  //creating new method 
  public getEmployees(): Observable<any>
  {
    return this.http.get(this.basePath)
  }

  public addEmployee(model: AddEmployeeRequest):Observable<any>
  {
    return this.http.post(this.basePath,model);
  }

  public getDepartment(): Observable<any>
  {
    return this.http.get('https://localhost:44313/api/Department');
  }  

  public DeleteEmployeeByID(id:any): Observable<any>
  {    
    return this.http.delete(this.basePath+'/'+id);    
  }

  public getEmployeeByName(name:any): Observable<any>
  {
    //alert(this.basePath+'/name/'+name);
    return this.http.get(this.basePath+'/name/'+name);
  }

  public getEmployeesByID(id:any): Observable<any>
  {
    return this.http.get(this.basePath+'/'+id)
  }

  public UpdateEmployeeByID(model:AddEmployeeRequest,id:any): Observable<any>
  {    
    return this.http.put(this.basePath+'/'+id,model)
  }

}
