import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerGetAllAppointmentsComponent } from './owner.get-all-appointments.component';

describe('OwnerGetAllAppointmentsComponent', () => {
  let component: OwnerGetAllAppointmentsComponent;
  let fixture: ComponentFixture<OwnerGetAllAppointmentsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OwnerGetAllAppointmentsComponent]
    });
    fixture = TestBed.createComponent(OwnerGetAllAppointmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
