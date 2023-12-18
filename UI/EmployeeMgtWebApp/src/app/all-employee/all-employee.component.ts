import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-all-employee',
  templateUrl: './all-employee.component.html',
  styleUrls: ['./all-employee.component.scss']
})
export class AllEmployeeComponent implements OnInit {

  public Employee: any;
  public GetEmpID: any;
  public SearchText:any;

  public GetUpdatedEmpID:any;

  constructor(private service: EmployeeService,private router: Router){}

  ngOnInit(): void {
    this.getEmployee();
  }

  private getEmployee():void{
    this.service.getEmployees().subscribe(result =>{
      this.Employee=result;
    })
  }

  private deleteEmpByID(id:any): void {
    this.service.DeleteEmployeeByID(id).subscribe(result => {
      this.Employee = result;
    });
  }

  private GetEmpByName(name:any): void {
    this.service.getEmployeeByName(name).subscribe(result => {
      this.Employee = result;
    });
  }

  getSelectedValue(event: any) {
    this.GetEmpID = event.target.value;
    let text = "Are you sure you want to delete this record";
    if (confirm(text) == true)
    {      
      this.deleteEmpByID(this.GetEmpID); 
      alert('Record Deleted');
      this.ngOnInit();
      this.getEmployee();      
    }    
  }

  getSearch(event: any) {
     this.SearchText=event.target.value;
     this.GetEmpByName(this.SearchText);
     this.ngOnInit();
    //  this.getEmployee();  
  }

  getUpSelectedValue(event: any) {
    this.GetUpdatedEmpID = event.target.value;   
    this.service.EmpIDGlo=this.GetUpdatedEmpID;    
    this.router.navigate(['/emps/add/']);        
  }


}
