import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PizzaCrustComponent } from './pizza-crust.component';

describe('PizzaCrustComponent', () => {
  let component: PizzaCrustComponent;
  let fixture: ComponentFixture<PizzaCrustComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PizzaCrustComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PizzaCrustComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
