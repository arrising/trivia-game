import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { SessionQuestion } from './game-session-state';
import { Update, EntityMap, EntityMapOne, Predicate } from '@ngrx/entity';

export const sessionQuestionActions = createActionGroup({
    source: 'Session Questions',
    events: {
        'Load Questions': props<{ questions: SessionQuestion[] }>(),
        'Load Questions Failure': (error: Error) => ({ error }),
        'Clear Questions': emptyProps(),
        'Set Question': props<{ question: SessionQuestion }>(),
        'Set Questions': props<{ questions: SessionQuestion[] }>(),
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
