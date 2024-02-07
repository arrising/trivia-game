import { createFeatureSelector, createSelector } from '@ngrx/store';
import { RoundStoreState, featureId } from './game-round-state';
import * as fromReducers from './game-round-reducers';

export const selectSessionState = createFeatureSelector<RoundStoreState>(featureId);

export const selectRoundState = createSelector(
    selectSessionState,
    state => state.rounds
);

export const selectRoundIds = createSelector(
    selectRoundState,
    fromReducers.selectRoundIds
);

export const selectRoundEntities = createSelector(
    selectRoundState,
    fromReducers.selectRoundEntities
);
export const selectAllRounds = createSelector(
    selectRoundState,
    fromReducers.selectAllRounds
);
export const selectRoundTotal = createSelector(
    selectRoundState,
    fromReducers.selectRoundTotal
);

export const getSelectedRoundId = createSelector(
    selectRoundState,
    (state) => state?.selectedRoundId
);

export const getSelectedRound = createSelector(
    selectRoundEntities,
    getSelectedRoundId,
    (questionEntities, id) => id && id !== '' ? questionEntities[id] : undefined
);
