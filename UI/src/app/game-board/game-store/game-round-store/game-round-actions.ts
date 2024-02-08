import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { Update, EntityMap, EntityMapOne, Predicate } from '@ngrx/entity';
import { SessionRound } from './game-round-state';

export const sessionRoundActions = createActionGroup({
    source: 'Session Rounds',
    events: {
        'Set Selected Round': props<{ id: string }>(),

        'Load Rounds': props<{ rounds: SessionRound[] }>(),
        'Load Rounds Failure': (error: any | Error) => ({ error }),
        'Clear Rounds': emptyProps(),
        'Set Round': props<{ round: SessionRound }>(),
        'Set Rounds': props<{ rounds: SessionRound[] }>(),
        'Add Round': props<{ round: SessionRound }>(),
        'Upsert Round': props<{ round: SessionRound }>(),
        'Add Rounds': props<{ rounds: SessionRound[] }>(),
        'Upsert Rounds': props<{ rounds: SessionRound[] }>(),
        'Update Round': props<{ update: Update<SessionRound> }>(),
        'Update Rounds': props<{ updates: Update<SessionRound>[] }>(),
        'Map Round': props<{ entityMap: EntityMapOne<SessionRound> }>(),
        'Map Rounds': props<{ entityMap: EntityMap<SessionRound> }>(),
        'Delete Round': props<{ id: string }>(),
        'Delete Rounds': props<{ ids: string[] }>(),
        'Delete Rounds By Predicate': props<{ predicate: Predicate<SessionRound> }>()
    }
});
