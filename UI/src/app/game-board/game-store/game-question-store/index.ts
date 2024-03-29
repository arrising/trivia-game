
import { ActionReducerMap } from '@ngrx/store';
import { featureId, QuestionStoreState } from './game-question-state';
import { sessionQuestionActions } from './game-question-actions';
import { SessionQuestionEffects } from './game-question-effects';
import * as questionReducers from './game-question-reducers';
import * as questionSelectors from './game-question-selectors';

export const featureKey = featureId;
export const actions = sessionQuestionActions;
export const effects = SessionQuestionEffects;
export const selectors = questionSelectors;
export const reducers: ActionReducerMap<QuestionStoreState> = {
    questions: questionReducers.questionReducer,
};
