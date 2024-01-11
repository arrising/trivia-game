import { Action, createReducer, on } from "@ngrx/store";
import { GameState, initialGameState } from "./game-session-state";
import * as actions from './game-session-actions';

const sessionGameReducer = createReducer(
    initialGameState,
    on(actions.sessionGameActions.loadGame, (state, { gameId }) => ({
        ...state,
        selectedGameId: gameId,
        selectedGame: undefined
    })),
    on(actions.sessionGameActions.setGame, (state, { game }) => ({
        ...state,
            selectedGameId: game.id,
            selectedGame: game
    })),
);

export function reducer(state: GameState | undefined, action: Action) {
    return sessionGameReducer(state, action);
}
