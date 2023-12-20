import { Component, OnInit } from '@angular/core';
import { DepatmentService } from '../depatment.service';
import { Router } from '@angular/router';
import { AddDepartmentComponent } from '../add-department/add-department.component';


@Component({
  selector: 'app-all-department',
  templateUrl: './all-department.component.html',
  styleUrls: ['./all-department.component.scss']
})
export class AllDepartmentComponent implements OnInit {

  public Departments: any;
  public GetDeptID: any;
  public SearchText:any;
  
  public constructor(private service: DepatmentService,private router: Router) { }
  
  ngOnInit(): void {
    this.getDepartment();
  }

  private getDepartment(): void {
    this.service.getDepartments().subscribe(result => {
      this.Departments = result;
    });
  }

  private deleteDepartmentByID(id:any): void {
    this.service.DeleteDepartmentsByID(id).subscribe(result => {
      //alert(result);
      //this.Departments = result;
    });
  }

  getSelectedValue(event: any) {
    this.GetDeptID = event.target.value;
    let text = "Are you sure you want to delete this record";
    if (confirm(text) == true)
    {      
      this.deleteDepartmentByID(this.GetDeptID); 
      alert('Record Deleted');
      this.ngOnInit();
      this.getDepartment();      
    }    
  }

  getUpSelectedValue(event: any) {
    this.GetDeptID = event.target.value;   
    this.service.DeptIDGlo=this.GetDeptID;
    this.router.navigate(['/depts/add/']);        
  }

  getSearch(event:any){
    this.SearchText=event.target.value;
    this.GetDeptByName(this.SearchText);
    this.ngOnInit();
  }

  private GetDeptByName(name:any): void {
    this.service.getDepartmentByName(name).subscribe(result => {
      this.Departments = result;
    });
  }

//   deleteRow(id:any){

//     for(let i = 0; i < this.Departments.length; ++i){
//         if (this.Departments[i].id === id) {
//             this.Departments.splice(i,1);
            
//         }
//     }
// }


}
