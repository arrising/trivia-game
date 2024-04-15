import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { GameService } from "src/app/data/game.service";
import { catchError, exhaustMap, forkJoin, map, of } from "rxjs";
import * as fromStore from '..';
import { SessionQuestion } from "./game-question-state";

@Injectable()
export class SessionQuestionEffects {
    onLoadCategories_loadQuestions$ = createEffect(() =>
        this.actions$.pipe(
            ofType(fromStore.category.actions.loadCategories),
            exhaustMap((action) =>
                forkJoin(
                    action.categories.map(x => x.id).flat().map((id) =>
                        this.gameService.getQuestions(id).pipe(
                            map((questions) => questions ? questions : []),
                            catchError((error) =>
                                of(fromStore.game.actions.loadGameFailure({ error })),
                            ),
                        ),
                    ),
                ),
            ),
            map(responseArray => {
                var questions = responseArray.filter(x => Array.isArray(x)).flat() as SessionQuestion[];
                var errors = responseArray.filter(x => !Array.isArray(x));
                return errors.length === 0 ? fromStore.questions.actions.loadQuestions({ questions })
                    : fromStore.questions.actions.loadQuestionsFailure({ error: { message: "Questions not found for Category" }, errors });
            }),
        ),
    );

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
