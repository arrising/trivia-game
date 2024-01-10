import { Game } from "src/app/models/game";

export interface currentGame extends Game {
    currentRound?: string;
}