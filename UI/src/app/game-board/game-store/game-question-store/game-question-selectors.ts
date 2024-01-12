import { createFeatureSelector, createSelector } from '@ngrx/store';
import { QuestionStoreState, featureId } from './game-question-state';
import * as fromReducers from './game-question-reducers';

export const selectSessionState = createFeatureSelector<QuestionStoreState>(featureId);

export const selectQuestionState = createSelector(
    selectSessionState,
    state => state.questions
);

export const selectQuestionIds = createSelector(
    selectQuestionState,
    fromReducers.selectQuestionIds // shorthand for usersState => sessionReducers.selectQuestionIds(usersState)
);

export const selectQuestionEntities = createSelector(
    selectQuestionState,
    fromReducers.selectQuestionEntities
);
export const selectAllQuestions = createSelector(
    selectQuestionState,
    fromReducers.selectAllQuestions
);
export const selectQuestionTotal = createSelector(
    selectQuestionState,
    fromReducers.selectQuestionTotal
);
export const selectCurrentQuestionId = createSelector(
    selectQuestionState,
    fromReducers.getSelectedQuestionId
);

export const selectCurrentQuestion = createSelector(
    selectQuestionEntities,
    selectCurrentQuestionId,
    (questionEntities, userId) => userId && questionEntities[userId]
);
