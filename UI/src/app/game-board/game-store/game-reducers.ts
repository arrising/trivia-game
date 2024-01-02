import { Action, createReducer, on } from "@ngrx/store";
import { GameState, initialGameState } from "./game-state";
import * as actions from './game-actions';

const gameBoardReducer = createReducer(
    initialGameState,
    on( actions.loadGame, state => ({ ...state, currentGame: undefined })),
    on( actions.gameLoaded, (state, { game }) => ({ ...state, currentGame: game })),
  );
  
  export function reducer(state: GameState | undefined, action: Action) {
    return gameBoardReducer(state, action);
  }
  