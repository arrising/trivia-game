import { createReducer, on } from '@ngrx/store';
import { CategoryState, initialCategoryState, categoryAdapter } from './game-category-state';
import { sessionCategoryActions as categoryActions } from './game-category-actions';

export const categoryReducer = createReducer(
    initialCategoryState,
    on(categoryActions.addCategory, (state, { category }) => {
      return categoryAdapter.addOne(category, state)
    }),
    on(categoryActions.setCategory, (state, { category }) => {
      return categoryAdapter.setOne(category, state)
    }),
    on(categoryActions.upsertCategory, (state, { category }) => {
      return categoryAdapter.upsertOne(category, state);
    }),
    on(categoryActions.addCategories, (state, { categories }) => {
      return categoryAdapter.addMany(categories, state);
    }),
    on(categoryActions.upsertCategories, (state, { categories }) => {
      return categoryAdapter.upsertMany(categories, state);
    }),
    on(categoryActions.updateCategory, (state, { update }) => {
      return categoryAdapter.updateOne(update, state);
    }),
    on(categoryActions.updateCategories, (state, { updates }) => {
      return categoryAdapter.updateMany(updates, state);
    }),
    on(categoryActions.mapCategory, (state, { entityMap }) => {
      return categoryAdapter.mapOne(entityMap, state);
    }),
    on(categoryActions.mapCategories, (state, { entityMap }) => {
      return categoryAdapter.map(entityMap, state);
    }),
    on(categoryActions.deleteCategory, (state, { id }) => {
      return categoryAdapter.removeOne(id, state);
    }),
    on(categoryActions.deleteCategories, (state, { ids }) => {
      return categoryAdapter.removeMany(ids, state);
    }),
    on(categoryActions.deleteCategoriesByPredicate, (state, { predicate }) => {
      return categoryAdapter.removeMany(predicate, state);
    }),
    on(categoryActions.loadCategories, (state, { categories }) => {
      return categoryAdapter.setAll(categories, state);
    }),
    on(categoryActions.setCategories, (state, { categories }) => {
      return categoryAdapter.setMany(categories, state);
    }),
    on(categoryActions.clearCategories, state => {
        return { ...state, Categories: categoryAdapter.removeAll({ ...state, selectedCategoryId: undefined }) };
    }),
    on(categoryActions.setSelectedCategory, (state, { id }) => ({
      ...state,
      selectedCategoryId: id
    }))
  );
   
  export const getSelectedCategoryId = (state: CategoryState) => state.selectedCategoryId;
   
  // get the selectors
  const {
    selectIds,
    selectEntities,
    selectAll,
    selectTotal,
  } = categoryAdapter.getSelectors();
   
  // select the array of category ids
  export const selectCategoryIds = selectIds;
   
  // select the dictionary of category entities
  export const selectCategoryEntities = selectEntities;
   
  // select the array of categories
  export const selectAllCategories = selectAll;
   
  // select the total category count
  export const selectCategoryTotal = selectTotal;
