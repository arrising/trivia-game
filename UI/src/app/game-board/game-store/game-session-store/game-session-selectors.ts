import { createFeatureSelector, createSelector } from '@ngrx/store';
import { GameState, featureId } from './game-session-state';

export const selectSessionState = createFeatureSelector<GameState>(featureId);

export const selectGameState = createSelector(
    selectSessionState,
    state => state
);

export const getSelectedGameId = createSelector(
    selectSessionState,
    state => state?.selectedGameId
);

export const selectCurrentGame = createSelector(
    selectGameState,
    (state: GameState | undefined) => state?.selectedGame ?? undefined
);

export const selectCurrentGameId = createSelector(
    selectGameState,
    (state: GameState | undefined) => state?.selectedGame?.id ?? undefined
);
