import { game } from "src/app/models/game";

export interface currentGame extends game {
    currentRound?: string;
}