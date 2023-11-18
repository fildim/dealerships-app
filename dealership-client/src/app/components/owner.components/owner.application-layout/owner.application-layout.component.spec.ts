import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerApplicationLayoutComponent } from './owner.application-layout.component';

describe('OwnerApplicationLayoutComponent', () => {
  let component: OwnerApplicationLayoutComponent;
  let fixture: ComponentFixture<OwnerApplicationLayoutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OwnerApplicationLayoutComponent]
    });
    fixture = TestBed.createComponent(OwnerApplicationLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
