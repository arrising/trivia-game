import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { switchMap, withLatestFrom } from 'rxjs';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import * as sessionStore from '.';

@Injectable()
export class SessionNavigationEffects {
    ExitGames$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(sessionStore.actions.navigation.exitGames),
            switchMap(() => {
                console.log('exit game play mode');
                return this.router.navigate(['/']);
            })
        );
    }, { dispatch: false });

    ViewGameSelector$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(sessionStore.actions.navigation.viewGameSelector),
            switchMap(() => {
                return this.router.navigate(['/games']);
            })
        );
    }, { dispatch: false });

    constructor(
        private actions$: Actions,
        private store: Store<any>,
        private router: Router,
    ) { }
}
