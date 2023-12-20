import { Component } from '@angular/core';
import { AddDepartmentRequest } from '../models/add-department-request.model';
import { DepatmentService } from '../depatment.service';
import { empty } from 'rxjs';
import { Router } from '@angular/router';


@Component({
  selector: 'app-add-department',
  templateUrl: './add-department.component.html',
  styleUrls: ['./add-department.component.scss']  
})
export class AddDepartmentComponent {

 public model: AddDepartmentRequest;
 public UpdateDeptID:any;

  constructor(private departmentService: DepatmentService,private router: Router) {    
      this.model={
        DepartmentName: '',  
        deleteFlag:0,
        mDate:new Date()
      }
      this.UpdateDeptID=0;
      if(this.departmentService.DeptIDGlo !=0)
      {
          this.GetDeptByID(this.departmentService.DeptIDGlo);
          this.UpdateDeptID=this.departmentService.DeptIDGlo;
          this.departmentService.DeptIDGlo=0;
      }

  }

  onFormSubmit(){    

    if(this.UpdateDeptID==0)
    {
      //insert
      //alert('insert');
      this.departmentService.addDepartments(this.model).subscribe(result => {
       // alert('done');
        alert(`New Department added with ID  = ${result}`);
        this.model.DepartmentName='';
        this.model.deleteFlag=0;
        this.model.mDate= new Date();
        this.UpdateDeptID=0;       
        //alert('done2'); 
      });
    }
    else
    {
      
      this.departmentService.UpdateDepartmentsByID(this.model,this.UpdateDeptID).subscribe(result => {

        alert(`Department Updated with = ${result}`);
        this.model.DepartmentName='';
        this.model.deleteFlag=0;
        this.model.mDate=new Date();
        this.UpdateDeptID=0;
        this.router.navigate(['/depts']); 
      });
    }
    
    

  }
   
  private GetDeptByID(id:any): void {
    this.departmentService.getDepartmentsByID(id).subscribe(result => {
      this.model = result;      
      this.model.DepartmentName=result.departmentName;
      this.model.deleteFlag=result.deleteFlag;
      this.model.mDate=result.mDate;

    });
  }

  

}
