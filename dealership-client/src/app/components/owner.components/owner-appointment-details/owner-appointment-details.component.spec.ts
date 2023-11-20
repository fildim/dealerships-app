import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerAppointmentDetailsComponent } from './owner-appointment-details.component';

describe('OwnerAppointmentDetailsComponent', () => {
  let component: OwnerAppointmentDetailsComponent;
  let fixture: ComponentFixture<OwnerAppointmentDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OwnerAppointmentDetailsComponent]
    });
    fixture = TestBed.createComponent(OwnerAppointmentDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
