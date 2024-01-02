import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { GameService } from "src/app/data/game.service";
import * as fromGameStore from './index';
import { EMPTY, catchError, exhaustMap, map, of } from "rxjs";

@Injectable()
export class GameEffects {

    login$ = createEffect(() =>
        this.actions$.pipe(
            ofType(fromGameStore.actions.loadGame),
            exhaustMap(action =>
                this.gameService.getGame(action.gameId).pipe(
                    map(game => game ? fromGameStore.actions.gameLoaded({ game })
                        : fromGameStore.actions.gameLoadError({ error: { message: "Game not Found", id: action.gameId } })),
                    catchError(error => of(fromGameStore.actions.gameLoadError({ error })))
                )
            )
        )
    );


    /*
    
        login$ = createEffect(() =>
        this.actions$.pipe(
          ofType(fromGameStore.actions.loadGame),
          exhaustMap(action =>
            this.gameService.getGame(action.gameId).pipe(
              map(game =>
                game !== undefined ? 
                 fromGameStore.actions.gameLoaded({ game })
                 : fromGameStore.actions.gameLoadError({ error: { message: 'game not found', id: action.gameId}}),
              catchError(error => of(fromGameStore.actions.gameLoadError({ error })))
            )
          )
        )
      );
    */

    constructor(
        private actions$: Actions,
        private gameService: GameService
    ) { }
}