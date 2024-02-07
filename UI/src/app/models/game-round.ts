import { GameCategory } from './game-category';

export interface GameRound {
    id: string;
    type: string;
    categoryIds: Array<string>
    categories: Array<GameCategory>
}