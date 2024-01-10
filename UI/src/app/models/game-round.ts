import { GameCategory } from './game-category';

export interface GameRound {
    id: string;
    type: string;
    isCompleted: boolean;
    categories: Array<GameCategory>
}