import { createFeatureSelector, createSelector } from '@ngrx/store';
import { QuestionStoreState, featureId } from './game-question-state';
import * as fromReducers from './game-question-reducers';

export const selectSessionState = createFeatureSelector<QuestionStoreState>(featureId);

export const selectQuestionState = createSelector(
    selectSessionState,
    state => state.questions
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
export const getSelectedQuestionId = createSelector(
    selectQuestionState,
    (state) => state?.selectedQuestionId
);

export const getSelectedQuestion = createSelector(
    selectQuestionEntities,
    getSelectedQuestionId,
    (questionEntities, id) => id && id !== '' ? questionEntities[id] : undefined
);

export const getQuestion = (props: { id: string }) =>
  createSelector(selectQuestionEntities, (questionEntities) => {
    return  props && props.id ? questionEntities[props.id] : undefined;
  });
