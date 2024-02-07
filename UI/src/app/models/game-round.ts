import { GameCategory } from './game-category';

export interface GameRound {
    id: string;
    type: string;
    categories: Array<GameCategory>
}