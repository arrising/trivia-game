import { sessionGameActions } from './game-session-actions';
import { SessionGameEffects } from './game-session-effects';
import { reducer } from './game-session-reducers';
import { featureId } from './game-session-state';
import * as fromSelectors from './game-session-selectors';

export const featureKey = featureId;
export const actions = sessionGameActions;
export const effects = SessionGameEffects;
export const reducers = reducer;
export const selectors = fromSelectors;