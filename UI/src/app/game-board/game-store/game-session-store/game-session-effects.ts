import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, of, switchMap, withLatestFrom } from 'rxjs';
import { Store } from '@ngrx/store';
import { GameService } from 'src/app/data/game.service';
import * as sessionStore from '..';

@Injectable()
export class SessionGameEffects {
    loadGame$ = createEffect(() => this.actions$.pipe(
        ofType(sessionStore.game.actions.loadGame), switchMap((action) =>
            this.gameService.getGame(action.gameId).pipe(
                map(game => {
                    return game ? sessionStore.game.actions.setGame({ game })
                        : sessionStore.game.actions.loadGameFailure({ error: { message: "Game not Found", id: action.gameId } })
                }),
                catchError(error => of(sessionStore.game.actions.loadGameFailure({ error })))
            ))
    ));

    GameLoaded$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(sessionStore.game.actions.setGame),
            switchMap(() => [sessionStore.navigation.actions.viewRoundSelector()])
        );
    });

    constructor(
        private actions$: Actions,
        private store: Store<any>,
        private gameService: GameService
    ) { }
}
