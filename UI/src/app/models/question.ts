export interface question {
    id: string;
    ask: string;
    answer: string;
    alternatives?: Array<string>;
    note?: string;
}
