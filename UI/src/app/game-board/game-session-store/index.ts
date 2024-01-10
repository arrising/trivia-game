import { ActionReducerMap, } from '@ngrx/store';
import * as navigationActions from './session-navigation-actions';
import * as navigationEffects from './session-navigation-effects';
import * as questionActions from './session-question-actions';
import * as sessionEffects from './session-question-effects';
import * as questionReducers from './session-question-reducers';
import * as questionSelectors from './session-question-selectors';
import * as fromState from './game-session-state';

export interface SessionState {
    session: fromState.SessionState;
}

export const featureKey = fromState.featureId;
export const actions = {
    navigation: navigationActions.sessionNavigationActions,
    questions: questionActions.sessionQuestionActions
};
export const effects = {
    navigation: navigationEffects.SessionNavigationEffects,
    questions: sessionEffects.GameSessionEffects
};
export const selectors = {
    questions: questionSelectors
};
export const reducers: ActionReducerMap<SessionState> = {
    session: questionReducers.questionReducer,
};
