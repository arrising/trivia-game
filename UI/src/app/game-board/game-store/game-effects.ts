import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { GameService } from "src/app/data/game.service";
import { EMPTY, catchError, exhaustMap, map, of } from "rxjs";
import * as actions from './game-actions'

@Injectable()
export class GameEffects {

    login$ = createEffect(() =>
        this.actions$.pipe(
            ofType(actions.loadGame),
            exhaustMap(action =>
                this.gameService.getGame(action.gameId).pipe(
                    map(game => game ? actions.gameLoaded({ game })
                        : actions.gameLoadError({ error: { message: "Game not Found", id: action.gameId } })),
                    catchError(error => of(actions.gameLoadError({ error })))
                )
            )
        )
    );

    constructor(
        private actions$: Actions,
        private gameService: GameService
    ) { }
}