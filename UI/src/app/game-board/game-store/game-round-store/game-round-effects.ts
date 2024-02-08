import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { GameService } from "src/app/data/game.service";
import { catchError, map, of, switchMap } from "rxjs";
import * as fromStore from '..';

@Injectable()
export class SessionRoundEffects {
    onSetGame_LoadRounds$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.game.actions.setGame),
            switchMap((action) => {
                var allIds = action.game.roundIds;
                return this.gameService.getRounds(allIds).pipe(
                    map(rounds => {
                        return rounds ? fromStore.rounds.actions.loadRounds({ rounds })
                            : fromStore.rounds.actions.loadRoundsFailure({ error: { message: "Round not Found", id: 'TBD' } })
                    }),
                    catchError(error => of(fromStore.game.actions.loadGameFailure({ error })))
                );
            })
        );
    });
    
    onSelectRound_setSelectedRound$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.game.actions.selectRound),
            map((action) => action.roundId
            ? fromStore.rounds.actions.setSelectedRound({ id: action.roundId })
            : fromStore.game.actions.doNothing())
        );
    });

    onSetSelectedRound_navigateToGameRoundPage$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.rounds.actions.setSelectedRound),
            map((_) => fromStore.navigation.actions.viewRound())
        );
    });
    
    constructor(
        private actions$: Actions,
        private store: Store<any>,
        private gameService: GameService
    ) { }
}
