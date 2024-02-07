import { EntityAdapter, EntityState, createEntityAdapter } from '@ngrx/entity';
import { Question } from 'src/app/models/question';

export const featureId = 'game-session-question';

export interface SessionQuestion extends Question {
    value?: number;
    isViewed?: boolean | undefined;
 }

export interface QuestionState extends EntityState<SessionQuestion> {
    selectedQuestionId: string | undefined;
}

export interface QuestionStoreState {
    questions: QuestionState;
}

export const questionAdapter: EntityAdapter<SessionQuestion> = createEntityAdapter<SessionQuestion>({
    selectId: (e) => e.id
});

export const initialQuestionState: QuestionState = questionAdapter.getInitialState({
    selectedQuestionId: undefined
});
