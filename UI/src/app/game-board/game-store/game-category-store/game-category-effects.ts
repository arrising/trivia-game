import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { GameService } from "src/app/data/game.service";
import { map } from "rxjs";
import * as fromStore from '..';

@Injectable()
export class SessionCategoryEffects {
    onCategoryLoaded$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.game.actions.setGame),
            map((action) => {
                var categories = action.game.rounds
                    .map(x => x.categories).flat();
                return fromStore.category.actions.loadCategories({ categories });
            })
        );
    });

    constructor(
        private actions$: Actions,
        private store: Store<any>,
        private gameService: GameService
    ) { }
}
