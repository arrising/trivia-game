export interface Question {
    id: string;
    ask: string;
    answer: string;
    alternatives?: Array<string>;
    note?: string;
}
export interface QuestionData extends Question {
    value: number;
}

export interface QuestionPointer {
    id: string;
    value: number;
}

// TODO:  Depricate
export interface GameQuestion {
    questionId: string;
    value: number;
}
