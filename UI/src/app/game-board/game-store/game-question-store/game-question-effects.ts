import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { GameService } from "src/app/data/game.service";
import { catchError, map, of, switchMap } from "rxjs";
import * as fromStore from '..';

@Injectable()
export class SessionQuestionEffects {
    onGameLoaded$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.game.actions.setGame),
            switchMap((action) => {
                var allIds = action.game.rounds
                    .map(x => x.categories).flat()
                    .map(x => x.questions).flat()
                    .map(x => x.questionId);

                return this.gameService.getQuestions(allIds).pipe(
                    map(questions => {
                        return questions ? fromStore.questions.actions.loadQuestions({ questions })
                            : fromStore.game.actions.loadGameFailure({ error: { message: "Game not Found", id: 'TBD' } })
                    }),
                    catchError(error => of(fromStore.game.actions.loadGameFailure({ error })))
                );
            })
        );
    });

    onSelectQuestion_setSelectedQuestion$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.game.actions.selectQuestion),
            map((action) => action.questionId
                ? fromStore.questions.actions.setSelectedQuestion({ id: action.questionId })
                : fromStore.game.actions.doNothing())
        );
    });

    onSelectQuestion_setSelectedQuestionViewedquestionAs$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.game.actions.selectQuestion),
            map((action) => action.questionId
                ? fromStore.questions.actions.updateQuestion({
                    update: {
                        id: action.questionId, changes: { isViewed: true }
                    }
                })
                : fromStore.game.actions.doNothing())
        );
    });

    onSetSelectedQuestion_navigateToGameQuestionPage$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.questions.actions.setSelectedQuestion),
            map((_) => fromStore.navigation.actions.viewQuestion())
        );
    });


    constructor(
        private actions$: Actions,
        private store: Store<any>,
        private gameService: GameService
    ) { }
}
