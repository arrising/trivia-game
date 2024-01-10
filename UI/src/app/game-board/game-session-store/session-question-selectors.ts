import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromState from './game-session-state';
import * as sessionReducers from './session-question-reducers';

export const selectSessionState = createFeatureSelector<fromState.SessionState>(fromState.featureId);

export const selectQuestionState = createSelector(
    selectSessionState,
    state => state.Questions
);

export const selectQuestionIds = createSelector(
    selectQuestionState,
    sessionReducers.selectQuestionIds // shorthand for usersState => sessionReducers.selectQuestionIds(usersState)
);

export const selectQuestionEntities = createSelector(
    selectQuestionState,
    sessionReducers.selectQuestionEntities
);
export const selectAllQuestions = createSelector(
    selectQuestionState,
    sessionReducers.selectAllQuestions
);
export const selectQuestionTotal = createSelector(
    selectQuestionState,
    sessionReducers.selectQuestionTotal
);
export const selectCurrentQuestionId = createSelector(
    selectQuestionState,
    sessionReducers.getSelectedQuestionId
);

export const selectCurrentQuestion = createSelector(
    selectQuestionEntities,
    selectCurrentQuestionId,
    (questionEntities, userId) => userId && questionEntities[userId]
);
