import * as gameActions from './game-actions';
import * as gameEffects from './game-effects';
import * as gameSelectors from './game-selectors';
import * as gameReducers from './game-reducers';

export const featureKey = "game-store";
export const actionType = gameActions.GameActionType;
export const actions = gameActions;
export const effects = gameEffects.GameEffects;
export const selectors = gameSelectors;
export const reducers = gameReducers.reducer;
