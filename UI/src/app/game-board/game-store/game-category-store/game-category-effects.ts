import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { GameService } from "src/app/data/game.service";
import { catchError, map, of, switchMap } from "rxjs";
import * as fromStore from '..';

@Injectable()
export class SessionCategoryEffects {
    onselectRound_loadCategories$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.rounds.actions.selectRound),
            switchMap((action) => {
                var roundId = action.roundId;
                return this.gameService.getCategories(roundId).pipe(
                    map(categories => {
                        return categories ? fromStore.category.actions.loadCategories({ categories })
                            : fromStore.category.actions.loadCategoriesFailure({ error: { message: "Categories not found for Round", id: roundId } })
                    }),
                    catchError(error => of(fromStore.game.actions.loadGameFailure({ error })))
                );
            })
        );
    });
    
    constructor(
        private actions$: Actions,
        private store: Store<any>,
        private gameService: GameService
    ) { }
}
