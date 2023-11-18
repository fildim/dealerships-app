import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAppointmentByIdComponent } from './get-appointment-by-id.component';

describe('GetAppointmentByIdComponent', () => {
  let component: GetAppointmentByIdComponent;
  let fixture: ComponentFixture<GetAppointmentByIdComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetAppointmentByIdComponent]
    });
    fixture = TestBed.createComponent(GetAppointmentByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
