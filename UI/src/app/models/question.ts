export interface Question {
    questionId: string;
    ask: string;
    answer: string;
    alternatives?: Array<string>;
    note?: string;
}
