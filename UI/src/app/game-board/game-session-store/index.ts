import { ActionReducerMap, } from '@ngrx/store';
import * as sessionActions from './session-question-actions';
import * as sessionEffects from './session-question-effects';
import * as sessionReducers from './session-question-reducers';
import * as sessionSelectors from './session-question-selectors';
import * as fromState from './game-session-state';

export interface SessionState {
    session: fromState.SessionState;
}

export const featureKey = fromState.featureId;
export const actions = sessionActions;
export const effects = sessionEffects.GameSessionEffects;
export const selectors = sessionSelectors;
export const reducers: ActionReducerMap<SessionState> = {
    session: sessionReducers.questionReducer,
};
