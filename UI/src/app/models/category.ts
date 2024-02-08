import { GameQuestion, QuestionData, QuestionPointer } from "./question";

export interface Category {
    id: string;
    name: string;
    note?: string;
}

export interface CategoryData extends Category {
    questions: Array<QuestionData>;
}

export interface CategoryInstance extends Category {
    questions: Array<QuestionPointer>;
}

export interface GameCategory extends Category {
    questions: Array<GameQuestion>;
}
