import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayFruitComponent } from './display-fruit.component';

describe('DisplayFruitComponent', () => {
  let component: DisplayFruitComponent;
  let fixture: ComponentFixture<DisplayFruitComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DisplayFruitComponent]
    });
    fixture = TestBed.createComponent(DisplayFruitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
