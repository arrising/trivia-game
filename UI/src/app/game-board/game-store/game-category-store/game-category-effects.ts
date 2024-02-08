import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { GameService } from "src/app/data/game.service";
import { catchError, map, of, switchMap } from "rxjs";
import * as fromStore from '..';

@Injectable()
export class SessionCategoryEffects {
    onloadRounds_LoadCategories$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.rounds.actions.loadRounds),
            switchMap((action) => {
                var allIds = action.rounds.map(x => x.categoryIds).flat();

                return this.gameService.getCategories(allIds).pipe(
                    map(categories => {
                        return categories ? fromStore.category.actions.loadCategories({ categories })
                            : fromStore.game.actions.loadGameFailure({ error: { message: "Game not Found", id: 'TBD' } })
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
