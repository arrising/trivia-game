import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { GameService } from "src/app/data/game.service";
import { map } from "rxjs";
import * as fromStore from '..';

@Injectable()

export class SessionRoundEffects {

    onSetGame_setRounds$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.game.actions.setGame),
            map((action) => fromStore.rounds.actions.setRounds({ rounds: action?.game?.rounds })
            )
        );
    });

    onSetRounds_navigateToRoundSelectorPage$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.rounds.actions.setRounds),
            map((action) => fromStore.navigation.actions.viewRoundSelector())
        );
    });
    
    onLoadRound_selectRound$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.game.actions.loadRound),
            map((action) => action.roundId
            ? fromStore.rounds.actions.setSelectedRound({ id: action.roundId })
            : fromStore.game.actions.doNothing)
        );
    });

    onSetSelectedRound_navigateToGameRoundPage$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.rounds.actions.setSelectedRound),
            map((action) => fromStore.navigation.actions.viewRound())
        );
    });
    constructor(
        private actions$: Actions,
        private store: Store<any>,
        private gameService: GameService
    ) { }
}
