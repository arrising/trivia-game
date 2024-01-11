import { Game } from "src/app/models/game";

export const featureId = 'game-session-game';

export interface SessionGame extends Game { }

export interface GameState {
    selectedGameId: string | undefined;
    selectedGame: SessionGame | undefined;
}

export const initialGameState: GameState = {
    selectedGameId: undefined,
    selectedGame: undefined
};
