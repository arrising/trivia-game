import { EntityAdapter, EntityState, createEntityAdapter } from '@ngrx/entity';
import { CategoryInstance } from 'src/app/models/category';

export const featureId = 'game-session-category';

export interface SessionCategory extends CategoryInstance {
    isComplete?: boolean | undefined;
 }

export interface CategoryState extends EntityState<SessionCategory> {
    selectedCategoryId: string | undefined;
}

export interface CategoryStoreState {
    categories: CategoryState;
}

export const categoryAdapter: EntityAdapter<SessionCategory> = createEntityAdapter<SessionCategory>({
    selectId: (e) => e.id
});

export const initialCategoryState: CategoryState = categoryAdapter.getInitialState({
    selectedCategoryId: undefined
});
