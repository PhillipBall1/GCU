import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteFruitComponent } from './delete-fruit.component';

describe('DeleteFruitComponent', () => {
  let component: DeleteFruitComponent;
  let fixture: ComponentFixture<DeleteFruitComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteFruitComponent]
    });
    fixture = TestBed.createComponent(DeleteFruitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
