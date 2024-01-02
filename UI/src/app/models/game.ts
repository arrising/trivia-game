import { gameRound } from "./game-round";

export interface game {
    id: string;
    name: string;
    valueSymbol: string;
    rounds: Array<gameRound>;
}