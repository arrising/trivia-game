import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { GameService } from "src/app/data/game.service";
import { catchError, map, of, switchMap } from "rxjs";
import * as gameStore from './index';

@Injectable()
export class GameEffects {
    loadGame$ = createEffect(() =>
        this.actions$.pipe(
            ofType(gameStore.actions.loadGame),
            switchMap((action) =>
                this.gameService.getGame(action.gameId).pipe(
                    map(game => {
                        return game ? gameStore.actions.gameLoaded({ game })
                            : gameStore.actions.gameLoadError({ error: { message: "Game not Found", id: action.gameId } })
                    }),
                    catchError(error => of(gameStore.actions.gameLoadError({ error })))
                )
            )
        )
    );

    GameLoaded$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(gameStore.actions.gameLoaded),
            switchMap((action) => {
                return this.router.navigate(['/games', 'game', action.game.id]);
            })
        );
    }, { dispatch: false });

    StartRound$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(gameStore.actions.startRound),
            switchMap((action) => {
                return this.router.navigate(['/games', 'game', action.gameId, 'round', action.roundId]);
            })
        );
    }, { dispatch: false });

    ViewRound$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(gameStore.actions.viewRound),
            switchMap((action) => {
                return this.router.navigate(['/games', 'game', action.gameId, 'round', action.roundId]);
            })
        );
    }, { dispatch: false });

    ViewQuestion$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(gameStore.actions.viewQuestion),
            switchMap((action) => {
                return this.router.navigate(['/games', 'game', action.gameId, 'round', action.roundId, 'question', action.questionId]);
            })
        );
    }, { dispatch: false });
    
    ViewAnswer$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(gameStore.actions.viewAnswer),
            switchMap((action) => {
                return this.router.navigate(['/games', 'game', action.gameId, 'round', action.roundId, 'question', action.questionId, 'answer']);
            })
        );
    }, { dispatch: false });

    constructor(
        private actions$: Actions,
        private store: Store<any>,
        private router: Router,
        private gameService: GameService
    ) { }
}