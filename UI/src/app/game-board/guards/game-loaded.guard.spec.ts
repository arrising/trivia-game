import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { gameLoadedGuard } from './game-loaded.guard';

describe('gameLoadedGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => gameLoadedGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
