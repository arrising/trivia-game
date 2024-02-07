import { createFeatureSelector, createSelector } from '@ngrx/store';
import { CategoryStoreState, featureId } from './game-category-state';
import * as fromReducers from './game-category-reducers';

export const selectSessionState = createFeatureSelector<CategoryStoreState>(featureId);

export const selectCategoryState = createSelector(
    selectSessionState,
    state => state.categories
);

export const selectCategoryIds = createSelector(
    selectCategoryState,
    fromReducers.selectCategoryIds // shorthand for usersState => sessionReducers.selectCategoryIds(usersState)
);

export const selectCategoryEntities = createSelector(
    selectCategoryState,
    fromReducers.selectCategoryEntities
);
export const selectAllCategories = createSelector(
    selectCategoryState,
    fromReducers.selectAllCategories
);
export const selectCategoryTotal = createSelector(
    selectCategoryState,
    fromReducers.selectCategoryTotal
);
export const selectCurrentCategoryId = createSelector(
    selectCategoryState,
    fromReducers.getSelectedCategoryId
);

export const selectCurrentCategory = createSelector(
    selectCategoryEntities,
    selectCurrentCategoryId,
    (categoryEntities, id) => id && categoryEntities[id]
);

export const getCategory = (props: { id: string }) =>
  createSelector(selectCategoryEntities, (categoryEntities) => {
    return  props && props.id ? categoryEntities[props.id] : undefined;
  });
