import { EntityAdapter, EntityState, createEntityAdapter } from "@ngrx/entity";
import { Question } from "src/app/models/question";

export const featureId = 'session-store';

export interface SessionQuestion extends Question {
    questionId: string;
}

export interface QuestionState extends EntityState<SessionQuestion> { 
    selectedQuestionId: string | undefined;
}

export interface SessionState {
    Questions: QuestionState;
}

export const questionAdapter: EntityAdapter<SessionQuestion> = createEntityAdapter<SessionQuestion>({
    selectId: (e) => e.questionId
});

const initialQuestionState: QuestionState = questionAdapter.getInitialState({
    selectedQuestionId: undefined
});

export const initialState: SessionState = {
    Questions: initialQuestionState
};
