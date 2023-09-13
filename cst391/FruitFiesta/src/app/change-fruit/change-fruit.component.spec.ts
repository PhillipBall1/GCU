import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangeFruitComponent } from './change-fruit.component';

describe('ChangeFruitComponent', () => {
  let component: ChangeFruitComponent;
  let fixture: ComponentFixture<ChangeFruitComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ChangeFruitComponent]
    });
    fixture = TestBed.createComponent(ChangeFruitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
