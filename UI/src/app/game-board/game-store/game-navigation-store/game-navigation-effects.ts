import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { switchMap, withLatestFrom } from 'rxjs';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import * as sessionStore from '..';

@Injectable()
export class SessionNavigationEffects {
    onExitGames$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(sessionStore.navigation.actions.exitGames),
            switchMap(() => this.router.navigate(['/']))
        );
    }, { dispatch: false });

    onViewGameSelector$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(sessionStore.navigation.actions.viewGameSelector),
            switchMap((_) => this.router.navigate(['/games']))
        );
    }, { dispatch: false });

    onViewRoundSelector$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(sessionStore.navigation.actions.viewRoundSelector),
            withLatestFrom(this.store.select(sessionStore.game.selectors.getSelectedGameId)),
            switchMap(([_, gameId]) => this.router.navigate(['/games', 'game', gameId]))
        );
    }, { dispatch: false });

    onViewRound$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(sessionStore.navigation.actions.viewRound),
            withLatestFrom(
                this.store.select(sessionStore.game.selectors.getSelectedGameId),
                this.store.select(sessionStore.rounds.selectors.getSelectedRoundId)
            ),
            switchMap(([_, gameId, roundId]) => this.router.navigate(['/games', 'game', gameId, 'round', roundId]))
        );
    }, { dispatch: false });

    viewQuestion$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(sessionStore.navigation.actions.viewQuestion),
            withLatestFrom(
                this.store.select(sessionStore.game.selectors.getSelectedGameId),
                this.store.select(sessionStore.rounds.selectors.getSelectedRoundId),
                this.store.select(sessionStore.questions.selectors.getSelectedQuestionId)
            ),
            switchMap(([_, gameId, roundId, questionId]) => {
                console.log('SessionNavigationEffects viewQuestion', { action: _, gameId, roundId, questionId });
                return this.router.navigate(['/games', 'game', gameId, 'round', roundId, 'question', questionId]);
            })
        );
    }, { dispatch: false });
    
    viewAnswer$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(sessionStore.navigation.actions.viewAnswer),
            withLatestFrom(
                this.store.select(sessionStore.game.selectors.getSelectedGameId),
                this.store.select(sessionStore.rounds.selectors.getSelectedRoundId),
                this.store.select(sessionStore.questions.selectors.getSelectedQuestionId)
            ),
            switchMap(([_, gameId, roundId, questionId]) => {
                console.log('SessionNavigationEffects viewQuestion', { action: _, gameId, roundId, questionId });
                return this.router.navigate(['/games', 'game', gameId, 'round', roundId, 'question', questionId, 'answer']);
            })
        );
    }, { dispatch: false });

    constructor(
        private actions$: Actions,
        private store: Store<any>,
        private router: Router,
    ) { }
}
