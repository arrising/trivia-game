import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { Update, EntityMap, EntityMapOne, Predicate } from '@ngrx/entity';
import { SessionCategory } from './game-category-state';
import { GameCategory } from 'src/app/models/category';

export const sessionCategoryActions = createActionGroup({
    source: 'Session Categories',
    events: {
        'Set Selected category': props<{ id: string }>(),

        'Load Categories': props<{ categories: GameCategory[] }>(),
        'Load Categories Failure': (error: Error) => ({ error }),
        'Clear Categories': emptyProps(),
        'Set Category': props<{ category: SessionCategory }>(),
        'Set Categories': props<{ categories: SessionCategory[] }>(),
        'Add Category': props<{ category: SessionCategory }>(),
        'Upsert Category': props<{ category: SessionCategory }>(),
        'Add Categories': props<{ categories: SessionCategory[] }>(),
        'Upsert Categories': props<{ categories: SessionCategory[] }>(),
        'Update Category': props<{ update: Update<SessionCategory> }>(),
        'Update Categories': props<{ updates: Update<SessionCategory>[] }>(),
        'Map Category': props<{ entityMap: EntityMapOne<SessionCategory> }>(),
        'Map Categories': props<{ entityMap: EntityMap<SessionCategory> }>(),
        'Delete Category': props<{ id: string }>(),
        'Delete Categories': props<{ ids: string[] }>(),
        'Delete Categories By Predicate': props<{ predicate: Predicate<SessionCategory> }>()
    }
});
