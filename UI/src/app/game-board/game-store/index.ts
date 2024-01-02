import * as gameActions from './game-actions';
import * as gameReducers from './game-reducers';

export const featureKey = "game-store";
export const actionType = gameActions.GameActionType;
export const actions = gameActions;
export const reducers = gameReducers.reducer;
