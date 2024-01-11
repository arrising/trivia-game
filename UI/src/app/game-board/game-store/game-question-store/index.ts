
import { ActionReducerMap } from '@ngrx/store';
import { featureId, QuestionStoreState } from './game-question-state';
import * as questionActions from './game-question-actions';
import * as questionEffects from './game-question-effects';
import * as questionReducers from './game-question-reducers';
import * as questionSelectors from './game-question-selectors';

export const featureKey = featureId;
export const actions = questionActions.sessionQuestionActions;
export const effects = questionEffects.GameSessionEffects;
export const selectors = questionSelectors;

export const reducers: ActionReducerMap<QuestionStoreState> = {
    questions: questionReducers.questionReducer,
};
