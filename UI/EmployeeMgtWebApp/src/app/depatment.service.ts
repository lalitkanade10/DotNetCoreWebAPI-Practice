import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import { AddDepartmentRequest } from './models/add-department-request.model';

@Injectable({
  providedIn: 'root'
})
export class DepatmentService {

  private basePath ='https://localhost:44313/api/Department';
  public DeptIDGlo=0;


  constructor(private http:HttpClient) { }
  //creating new method 
  public getDepartments(): Observable<any>
  {
    return this.http.get(this.basePath)
  }

  public addDepartments(model:AddDepartmentRequest): Observable<any>
  {    
    //alert('h1');
    return this.http.post(this.basePath, model);    
  }

  public DeleteDepartmentsByID(id:any): Observable<any>
  {    
    return this.http.delete(this.basePath+'/'+id);    
  }  

  public getDepartmentsByID(id:any): Observable<any>
  {    
    return this.http.get(this.basePath+'/'+id)
  }

  public UpdateDepartmentsByID(model:AddDepartmentRequest,id:any): Observable<any>
  {    
    return this.http.put(this.basePath+'/'+id,model)
  }

  public getDepartmentByName(name:any): Observable<any>
  {
    //alert(this.basePath+'/name/'+name);
    return this.http.get(this.basePath+'/name/'+name);
  }

}
