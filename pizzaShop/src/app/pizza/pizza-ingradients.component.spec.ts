import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PizzaIngradientsComponent } from './pizza-ingradients.component';

describe('PizzaIngradientsComponent', () => {
  let component: PizzaIngradientsComponent;
  let fixture: ComponentFixture<PizzaIngradientsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PizzaIngradientsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PizzaIngradientsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
