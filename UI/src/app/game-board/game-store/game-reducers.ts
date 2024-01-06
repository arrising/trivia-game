import { Action, createReducer, on } from "@ngrx/store";
import { GameState, initialGameState } from "./game-state";
import * as actions from './game-actions';
import { currentGame } from "../game-models/current-game";

const gameBoardReducer = createReducer(
  initialGameState,
  on(actions.loadGame, state => ({ ...state, currentGame: undefined })),
  on(actions.gameLoaded, (state, { game }) => ({
    ...state,
    currentGame: game
  })),

  on(actions.startRound, (state, {roundId} ) => {
    const currentGame = {
      ...state.currentGame,
      currentRound: roundId
    } as currentGame;
    return {
      ...state,
      currentGame: currentGame
    }
  }),
);

export function reducer(state: GameState | undefined, action: Action) {
  return gameBoardReducer(state, action);
}
