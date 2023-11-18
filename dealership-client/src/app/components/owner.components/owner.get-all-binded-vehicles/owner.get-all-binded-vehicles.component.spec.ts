import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerGetAllBindedVehiclesComponent } from './owner.get-all-binded-vehicles.component';

describe('OwnerGetAllBindedVehiclesComponent', () => {
  let component: OwnerGetAllBindedVehiclesComponent;
  let fixture: ComponentFixture<OwnerGetAllBindedVehiclesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OwnerGetAllBindedVehiclesComponent]
    });
    fixture = TestBed.createComponent(OwnerGetAllBindedVehiclesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
