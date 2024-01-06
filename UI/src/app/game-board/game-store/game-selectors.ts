import { createSelector } from '@ngrx/store';
import { game } from 'src/app/models/game';
import { GameState } from './game-state';
import { currentGame } from '../game-models/current-game';

export const selectCurrentGame = (state: GameState) => state.currentGame;

export const getCurrentGameId = createSelector(
    selectCurrentGame,
    (selectedgame: game | undefined) => selectedgame?.id ?? undefined);

export const selectCurrentRoundId = createSelector(
    selectCurrentGame,
    (selectedgame: currentGame | undefined) => selectedgame?.currentRound ?? undefined);