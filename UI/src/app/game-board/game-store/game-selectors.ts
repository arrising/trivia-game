import { createSelector } from '@ngrx/store';
import { game } from 'src/app/models/game';
import * as fromGameStore from '.';

export const selectCurrentGame = (state: fromGameStore.GameState) => state.currentGame;

export const selectCurrentGameGameId = createSelector(
    selectCurrentGame,
    (selectedgame: game | undefined, ) => selectedgame?.id ?? undefined
    );
