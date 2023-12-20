import { Component } from '@angular/core';
import { AddEmployeeRequest } from '../models/add-employee-request.model';
import { EmployeeService } from '../employee.service';
import { empty } from 'rxjs';
import { DepatmentService } from '../depatment.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.scss']
})
export class AddEmployeeComponent {
  
  model: AddEmployeeRequest;
  public Departments: any;

  public UpdateEmpID:any;  
  public EmpDeptData:any;
  public TempDeptList:any;

  public FirstTimeFlag:any;


  constructor(private employeeService: EmployeeService,private router: Router){
    this.model={
      EmployeeName: '',
      EmailID: '',
      Address: '',
      Salary: 0,
      DeptID:0,
      DeleteFlag:0,
      MDate:new Date()
    }
    
    // for update

    this.getDept();
    this.UpdateEmpID=0;
    this.FirstTimeFlag=false;
    if(this.employeeService.EmpIDGlo !=0)
    {   
        this.GetEmpByID(this.employeeService.EmpIDGlo);
        this.UpdateEmpID=this.employeeService.EmpIDGlo;
        this.employeeService.EmpIDGlo=0;                     
        this.FirstTimeFlag=true;
    }    
    
  }
  
  onFormSubmit(){
    
    
    if(this.model.DeptID==0)
    {
      alert('Please Select Department From The List');
      return;
    }
    
    // this.employeeService.addEmployee(this.model).subscribe(result => {
    //   alert(`New book added with id  = ${result}`);      
    //   this.model.EmployeeName= '';
    //   this.model.EmailID= '';
    //   this.model.Address= '';
    //   this.model.Salary= 0;
    //   this.model.DeptID=0;
    //   this.model.DeleteFlag=0;
    //   this.model.MDate='2023-12-10';
    // });


    if(this.UpdateEmpID!=0)
    {
      // this code is for Update the data
       this.employeeService.UpdateEmployeeByID(this.model,this.UpdateEmpID).subscribe(result => {
        alert(`New Employee Update with = ${result}`);      
        this.model.EmployeeName= '';
        this.model.EmailID= '';
        this.model.Address= '';
        this.model.Salary= 0;
        this.model.DeptID=0;
        this.model.DeleteFlag=0;
        this.model.MDate=new Date();

        this.UpdateEmpID=0;
        this.FirstTimeFlag=false;
        this.employeeService.EmpIDGlo=0;
        this.router.navigate(['/emps']); 
      });
    }
    else
    {
      // this code is for save the data
      
      this.employeeService.addEmployee(this.model).subscribe(result => {
        alert(`New Employee added with id  = ${result}`);      
        this.model.EmployeeName= '';
        this.model.EmailID= '';
        this.model.Address= '';
        this.model.Salary= 0;
        this.model.DeptID=0;
        this.model.DeleteFlag=0;
        this.model.MDate=new Date();
        this.getDept();
        this.model.DeptID=0;
        
      });
    }

  }

  private getDept():void{
    this.employeeService.getDepartment().subscribe(result =>{
      this.Departments = result;
      this.TempDeptList=result;
    });
  }

  getUpSelectedValue(event:any):void{
    this.FirstTimeFlag=false;
    this.getDept();
    this.model.DeptID=0;
  }

  backToComponents(event:any):void{
        this.UpdateEmpID=0;
        this.FirstTimeFlag=false;
        this.employeeService.EmpIDGlo=0;
        this.router.navigate(['/emps']); 
  }

 
  getSelectedValue(event:any){
    this.model.DeptID = event.target.value;     
  }

  private GetEmpByID(id:any): void {
    this.employeeService.getEmployeesByID(id).subscribe(result => {
      this.model = result;      
      this.model.EmployeeName= result.employeeName;
      this.model.EmailID= result.emailID;
      this.model.Address= result.address;
      this.model.Salary= result.salary;
      this.model.DeptID=result.deptID;
      this.model.DeleteFlag=result.deleteFlag;
      this.model.MDate=result.mDate;
      this.Departments=null;

      this.Departments=[{
        deptID:result.deptID,
        departmentName:result.departmentName        
      }];


      

      console.log('Sarthak Bhau')
      for (var key in this.TempDeptList) {
        if (this.TempDeptList.hasOwnProperty(key)) {
           console.log(this.TempDeptList[key].deptID);
        }
     }

      
    //   for(var key in this.TempDeptList.jsonData) {
    //     for (var key1 in this.TempDeptList.jsonData[key]) {
    //         console.log(this.TempDeptList.jsonData[key][key1])
    //         alert('key');
    //     }
    //  }

  //    for(var key in this.TempDeptList) {
  //     for (var key1 in this.TempDeptList[key]) {
  //         console.log(this.TempDeptList[key][key1])
  //         alert('key');
  //     }
  //  }    

    });
  }

}
