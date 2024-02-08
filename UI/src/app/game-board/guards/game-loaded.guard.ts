import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { take } from 'rxjs';
import { Store, select } from '@ngrx/store';
import * as sessionStore from '../game-store';

export const gameLoadedGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  const store = inject(Store);
  var idFromStore: string | undefined;
  const idFromRoute = route.paramMap.get('gameId');

  store.pipe(select(sessionStore.game.selectors.getSelectedGameId), take(1))
    .subscribe(s => idFromStore = s);
    if (idFromRoute == idFromStore) {
      return true;
    }
    
    return router.parseUrl('/games');
};
