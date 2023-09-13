import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateFruitComponent } from './update-fruit.component';

describe('UpdateFruitComponent', () => {
  let component: UpdateFruitComponent;
  let fixture: ComponentFixture<UpdateFruitComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateFruitComponent]
    });
    fixture = TestBed.createComponent(UpdateFruitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
