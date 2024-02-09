import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoundSelectButtonComponent } from './round-select-button.component';

describe('RoundSelectButtonComponent', () => {
  let component: RoundSelectButtonComponent;
  let fixture: ComponentFixture<RoundSelectButtonComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RoundSelectButtonComponent]
    });
    fixture = TestBed.createComponent(RoundSelectButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
