import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { GameService } from "src/app/data/game.service";
import { map } from "rxjs";
import * as fromStore from '..';

@Injectable()

export class SessionRoundEffects {
    onCategoryLoaded$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.game.actions.setGame),
            map((action) => {
                var rounds = action.game.rounds;
                return fromStore.rounds.actions.loadRounds({ rounds });
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
