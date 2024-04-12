import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoundSelectorComponent } from './round-selector.component';

describe('RoundSelectorComponent', () => {
  let component: RoundSelectorComponent;
  let fixture: ComponentFixture<RoundSelectorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RoundSelectorComponent]
    });
    fixture = TestBed.createComponent(RoundSelectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
