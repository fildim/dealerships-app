import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GarageGetAllAppointmentsComponent } from './garage.get-all-appointments.component';

describe('GarageGetAllAppointmentsComponent', () => {
  let component: GarageGetAllAppointmentsComponent;
  let fixture: ComponentFixture<GarageGetAllAppointmentsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GarageGetAllAppointmentsComponent]
    });
    fixture = TestBed.createComponent(GarageGetAllAppointmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
