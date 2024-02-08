import { CategoryData } from './category';

export interface Round {
    id: string;
    type: string;
}

export interface RoundData extends Round {
    categoryies: Array<CategoryData>;
}

export interface RoundInstance extends Round {
    categoryIds: Array<string>;
}

export interface GameRound extends Round {
    categoryIds: Array<string>
}
