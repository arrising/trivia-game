import { RoundData } from "./round";

export interface Game {
    id: string;
    name: string;
    valueSymbol: string;
}

export interface GameInstance extends Game {
    roundIds: Array<string>;
}

export interface GameData extends Game {
    rounds: Array<RoundData>;
}
