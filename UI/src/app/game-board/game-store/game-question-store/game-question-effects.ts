import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { GameService } from "src/app/data/game.service";
import { catchError, map, of, switchMap } from "rxjs";
import * as fromStore from '..';
import { SessionQuestion } from "./game-question-state";

@Injectable()
export class SessionQuestionEffects {
    // TODO: this version only returns questions for a single category (the last)
    // Need to find a better way
    onLoadCategories_loadQuestions$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.category.actions.loadCategories),
            switchMap((action) => {
                var categoryIds = action.categories.map(x => x.id).flat();
                var events = categoryIds.map(x => fromStore.questions.actions.loadQuestions({ categoryId: x }))
                return events;
            })
        );
    });

    onLoadQuestions_addQuestions$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.questions.actions.loadQuestions),
            switchMap((action) => {
                var categoryId = action.categoryId;
                console.log('get questions by category', { categoryId });
                return this.gameService.getQuestions(categoryId).pipe(
                    map(questions => {
                        console.log('got questions', { categoryId, questions })
                        return questions ? fromStore.questions.actions.addQuestions({ questions })
                            : fromStore.questions.actions.loadQuestionsFailure({ error: { message: "Questions not found for Category", id: categoryId } })
                    }),
                    catchError(error => of(fromStore.game.actions.loadGameFailure({ error })))
                );
            })
        );
    });

/*
    onloadCategories_loadQuestions$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(fromStore.category.actions.loadCategories),
            switchMap((action) => {
                var allQuestions = action.categories
                    .map(x => x.questions).flat();
                var allIds = allQuestions.map(x => x.questionId);

                return this.gameService.getQuestions(allIds).pipe(
                    map(results => {
                        var questions = results?.map(x => ({
                            ...x,
                            value: allQuestions.find(q => q.questionId === x.id)?.value,
                            isViewed: false
                        } as SessionQuestion));
                        return questions ? fromStore.questions.actions.loadQuestions({ questions })
                            : fromStore.game.actions.loadGameFailure({ error: { message: "Game not Found", id: 'TBD' } })
                    }),
                    catchError(error => of(fromStore.game.actions.loadGameFailure({ error })))
                );
            })
        );
    });
*/

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
