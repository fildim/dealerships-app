import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerGetAllGaragesComponent } from './owner.get-all-garages.component';

describe('OwnerGetAllGaragesComponent', () => {
  let component: OwnerGetAllGaragesComponent;
  let fixture: ComponentFixture<OwnerGetAllGaragesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OwnerGetAllGaragesComponent]
    });
    fixture = TestBed.createComponent(OwnerGetAllGaragesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
