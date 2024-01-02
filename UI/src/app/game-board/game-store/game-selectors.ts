import { createSelector } from '@ngrx/store';
import { game } from 'src/app/models/game';
import { GameState } from './game-state';

export const selectCurrentGame = (state: GameState) => state.currentGame;

export const selectCurrentGameGameId = createSelector(
    selectCurrentGame,
    (selectedgame: game | undefined, ) => selectedgame?.id ?? undefined
    );
