import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { Update } from '@ngrx/entity';
import { SessionGame } from './game-session-state';

export const sessionGameActions = createActionGroup({
    source: 'Session Game',
    events: {
        'Load Game': props<{ gameId: string }>(),
        'Load Game Failure': (error: any | Error) => ({ error }),
        'Clear Games': emptyProps(),
        'Set Game': props<{ game: SessionGame }>(),
        'Upsert Game': props<{ game: SessionGame }>(),
        'Update Game': props<{ update: Update<SessionGame> }>(),

        'Load Round': props<{ roundId: string }>(),
        'Show Round': props<{ roundId: string }>(),
        'Show Question': props<{ questionId: string }>(),
        'Show Answer': props<{ questionId: string }>(),
    }
});
