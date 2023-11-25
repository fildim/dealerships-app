import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GarageUpdateVehicleComponent } from './garage.update-vehicle.component';

describe('GarageUpdateVehicleComponent', () => {
  let component: GarageUpdateVehicleComponent;
  let fixture: ComponentFixture<GarageUpdateVehicleComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GarageUpdateVehicleComponent]
    });
    fixture = TestBed.createComponent(GarageUpdateVehicleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
