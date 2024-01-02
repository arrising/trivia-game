import { Action, createReducer, on } from "@ngrx/store";
import * as fromGameStore from '.';

const gameBoardReducer = createReducer(
    fromGameStore.initialGameState,
    on( fromGameStore.actions.loadGame, state => ({ ...state, currentGame: undefined })),
    on( fromGameStore.actions.gameLoaded, (state, { game }) => ({ ...state, currentGame: game })),
  );
  
  export function reducer(state: fromGameStore.GameState | undefined, action: Action) {
    return gameBoardReducer(state, action);
  }
  