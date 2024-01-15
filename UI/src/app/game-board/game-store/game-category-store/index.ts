
import { ActionReducerMap } from '@ngrx/store';
import { featureId, CategoryStoreState } from './game-category-state';
import { sessionCategoryActions } from './game-category-actions';
import { SessionCategoryEffects } from './game-category-effects';
import * as categoryReducers from './game-category-reducers';
import * as categorySelectors from './game-category-selectors';

export const featureKey = featureId;
export const actions = sessionCategoryActions;
export const effects = SessionCategoryEffects;
export const selectors = categorySelectors;
export const reducers: ActionReducerMap<CategoryStoreState> = {
    categories: categoryReducers.categoryReducer,
};
