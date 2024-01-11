import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { GameService } from "src/app/data/game.service";
import { catchError, map, of, switchMap } from "rxjs";
import * as sessionStore from '..';

@Injectable()

export class GameSessionEffects {
    GameLoaded$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(sessionStore.game.actions.setGame),
            switchMap((action) => {
                var allIds = action.game.rounds
                    .map(x => x.categories).flat()
                    .map(x => x.questions).flat()
                    .map(x => x.questionId);

                return this.gameService.getQuestions(allIds).pipe(
                    map(questions => {
                        console.log('GameSessionEffects GameLoaded', { game: action.game, questions });
                        return questions ? sessionStore.questions.actions.loadQuestions({ questions })
                            : sessionStore.game.actions.loadGameFailure({ error: { message: "Game not Found", id: 'TBD' } })
                    }),
                    catchError(error => of(sessionStore.game.actions.loadGameFailure({ error })))
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
