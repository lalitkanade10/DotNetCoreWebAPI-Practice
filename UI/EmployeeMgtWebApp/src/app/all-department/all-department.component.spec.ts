import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllDepartmentComponent } from './all-department.component';

describe('AllDepartmentComponent', () => {
  let component: AllDepartmentComponent;
  let fixture: ComponentFixture<AllDepartmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AllDepartmentComponent]
    });
    fixture = TestBed.createComponent(AllDepartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
