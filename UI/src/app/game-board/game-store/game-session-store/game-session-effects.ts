import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, of, switchMap } from 'rxjs';
import { Store } from '@ngrx/store';
import { GameService } from 'src/app/data/game.service';
import * as sessionStore from '..';

@Injectable()
export class SessionGameEffects {
    onLoadGame_setGame$ = createEffect(() => this.actions$.pipe(
        ofType(sessionStore.game.actions.loadGame), switchMap((action) =>
            this.gameService.getGame(action.gameId).pipe(
                map(game => {
                    return game ? sessionStore.game.actions.setGame({ game })
                        : sessionStore.game.actions.loadGameFailure({ error: { message: "Game not Found", id: action.gameId } })
                }),
                catchError(error => of(sessionStore.game.actions.loadGameFailure({ error })))
            ))
    ));

    onGameLoaded_navigateToRoundSelectorPage$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(sessionStore.game.actions.setGame),
            switchMap(() => [sessionStore.navigation.actions.viewRoundSelector()])
        );
    });

    onShowRound_navigateToViewRoundPage$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(sessionStore.game.actions.showRound),
            switchMap(() => [sessionStore.navigation.actions.viewRound()])
        );
    });
    
    onShowAnswer_navigateToViewAnswerPage$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(sessionStore.game.actions.showAnswer),
            switchMap(() => [sessionStore.navigation.actions.viewAnswer()])
        );
    });
    
    constructor(
        private actions$: Actions,
        private store: Store<any>,
        private gameService: GameService
    ) { }
}
