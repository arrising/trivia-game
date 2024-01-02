import { category } from "./category";
import { gameQuestion } from "./game-question";

export interface gameCategory extends category{
    questions: Array<gameQuestion>;
}