import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GarageApplicationLayoutComponent } from './garage.application-layout.component';

describe('GarageApplicationLayoutComponent', () => {
  let component: GarageApplicationLayoutComponent;
  let fixture: ComponentFixture<GarageApplicationLayoutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GarageApplicationLayoutComponent]
    });
    fixture = TestBed.createComponent(GarageApplicationLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
