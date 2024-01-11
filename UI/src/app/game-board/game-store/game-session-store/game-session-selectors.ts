import { createFeatureSelector, createSelector } from '@ngrx/store';
import { GameState, featureId } from './game-session-state';

export const selectSessionState = createFeatureSelector<GameState>(featureId);

export const selectGameState = createSelector(
    selectSessionState,
    state => {
        var response = state;
        console.log('SessionGameSelector selectGameState', { state, response });
        return response;
    }
);

export const getSelectedGameId = createSelector(
    selectSessionState,
    state => {
        var response = state?.selectedGameId;
        console.log('SessionGameSelector getSelectedGameId', { state, response });
        return response;
    }
);

export const selectCurrentGame = createSelector(
    selectGameState,
    (state: GameState | undefined) => {
        var response = state?.selectedGame ?? undefined;
        console.log('SessionGameSelector selectCurrentGame', { state, response });
        return response;
    });

export const selectCurrentGameId = createSelector(
    selectGameState,
    (state: GameState | undefined) => {
        var response = state?.selectedGame?.id ?? undefined;
        console.log('SessionGameSelector selectCurrentGameId', { state, response });
        return response;
    });
