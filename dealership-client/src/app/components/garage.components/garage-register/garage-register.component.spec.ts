import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GarageRegisterComponent } from './garage-register.component';

describe('GarageRegisterComponent', () => {
  let component: GarageRegisterComponent;
  let fixture: ComponentFixture<GarageRegisterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GarageRegisterComponent]
    });
    fixture = TestBed.createComponent(GarageRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
