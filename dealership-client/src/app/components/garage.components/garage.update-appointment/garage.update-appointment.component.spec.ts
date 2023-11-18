import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GarageUpdateAppointmentComponent } from './garage.update-appointment.component';

describe('GarageUpdateAppointmentComponent', () => {
  let component: GarageUpdateAppointmentComponent;
  let fixture: ComponentFixture<GarageUpdateAppointmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GarageUpdateAppointmentComponent]
    });
    fixture = TestBed.createComponent(GarageUpdateAppointmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
