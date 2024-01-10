import { Category } from "./category";
import { GameQuestion } from "./game-question";

export interface GameCategory extends Category{
    questions: Array<GameQuestion>;
}