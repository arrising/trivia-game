import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { GameInstance } from 'src/app/models/game';

export const sessionGameActions = createActionGroup({
    source: 'Session Game',
    events: {
        'Clear Games': emptyProps(),

        'Load Game': props<{ gameId: string }>(),
        'Load Game Failure': (error: any | Error) => ({ error }),
        'Set Game': props<{ game: GameInstance }>(),

        'Show Round': emptyProps(),
        'Select Category': props<{ categoryId: string }>(),
        'Show Category': emptyProps(),
        'Select Question': props<{ questionId: string }>(),
        'Show Question': emptyProps(),
        'Show Answer': emptyProps(),

        'Do Nothing': emptyProps()
    }
});
