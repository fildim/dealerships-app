import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerCreateAppointmentComponent } from './owner.create-appointment.component';

describe('OwnerCreateAppointmentComponent', () => {
  let component: OwnerCreateAppointmentComponent;
  let fixture: ComponentFixture<OwnerCreateAppointmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OwnerCreateAppointmentComponent]
    });
    fixture = TestBed.createComponent(OwnerCreateAppointmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
