import { gameCategory } from './game-category';

export interface gameRound {
    id: string;
    type: string;
    isCompleted: boolean;
    categories: Array<gameCategory>
}