import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { Update, EntityMap, EntityMapOne, Predicate } from '@ngrx/entity';
import { SessionQuestion } from './game-question-state';

export const sessionQuestionActions = createActionGroup({
    source: 'Session Questions',
    events: {
        'Load Questions': props<{ categoryId: string }>(),
        'Load Questions Failure': (error: any | Error) => ({ error }),
        'Set Questions': props<{ questions: SessionQuestion[] }>(),
        'Set Selected question': props<{ id: string }>(),

        'Clear Questions': emptyProps(),
        'Set Question': props<{ question: SessionQuestion }>(),
        'Add Question': props<{ question: SessionQuestion }>(),
        'Upsert Question': props<{ question: SessionQuestion }>(),
        'Add Questions': props<{ questions: SessionQuestion[] }>(),
        'Upsert Questions': props<{ questions: SessionQuestion[] }>(),
        'Update Question': props<{ update: Update<SessionQuestion> }>(),
        'Update Questions': props<{ updates: Update<SessionQuestion>[] }>(),
        'Map Question': props<{ entityMap: EntityMapOne<SessionQuestion> }>(),
        'Map Questions': props<{ entityMap: EntityMap<SessionQuestion> }>(),
        'Delete Question': props<{ id: string }>(),
        'Delete Questions': props<{ ids: string[] }>(),
        'Delete Questions By Predicate': props<{ predicate: Predicate<SessionQuestion> }>()
    }
});
