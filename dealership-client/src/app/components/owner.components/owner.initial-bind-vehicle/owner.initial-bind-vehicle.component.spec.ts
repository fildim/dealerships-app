import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerInitialBindVehicleComponent } from './owner.initial-bind-vehicle.component';

describe('OwnerInitialBindVehicleComponent', () => {
  let component: OwnerInitialBindVehicleComponent;
  let fixture: ComponentFixture<OwnerInitialBindVehicleComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OwnerInitialBindVehicleComponent]
    });
    fixture = TestBed.createComponent(OwnerInitialBindVehicleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
