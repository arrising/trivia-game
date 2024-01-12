
import { ActionReducerMap } from '@ngrx/store';
import { featureId, RoundStoreState } from './game-round-state';
import { sessionRoundActions } from './game-round-actions';
import { SessionRoundEffects } from './game-round-effects';
import * as roundReducers from './game-round-reducers';
import * as roundSelectors from './game-round-selectors';

export const featureKey = featureId;
export const actions = sessionRoundActions;
export const effects = SessionRoundEffects;
export const selectors = roundSelectors;

export const reducers: ActionReducerMap<RoundStoreState> = {
    rounds: roundReducers.roundReducer,
};
