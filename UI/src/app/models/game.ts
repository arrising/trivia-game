import { GameRound } from "./game-round";

export interface Game {
    id: string;
    name: string;
    valueSymbol: string;
    rounds: Array<GameRound>;
}