import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameSelectButtonComponent } from './game-select-button.component';

describe('GameSelectButtonComponent', () => {
  let component: GameSelectButtonComponent;
  let fixture: ComponentFixture<GameSelectButtonComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GameSelectButtonComponent]
    });
    fixture = TestBed.createComponent(GameSelectButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
