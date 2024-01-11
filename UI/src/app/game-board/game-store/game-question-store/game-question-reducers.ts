import { createReducer, on } from '@ngrx/store';
import { QuestionState, initialQuestionState, questionAdapter } from './game-question-state';
import { sessionQuestionActions as questionActions } from './game-question-actions';

export const questionReducer = createReducer(
    initialQuestionState,
    on(questionActions.addQuestion, (state, { question }) => {
      return questionAdapter.addOne(question, state)
    }),
    on(questionActions.setQuestion, (state, { question }) => {
      return questionAdapter.setOne(question, state)
    }),
    on(questionActions.upsertQuestion, (state, { question }) => {
      return questionAdapter.upsertOne(question, state);
    }),
    on(questionActions.addQuestions, (state, { questions }) => {
      return questionAdapter.addMany(questions, state);
    }),
    on(questionActions.upsertQuestions, (state, { questions }) => {
      return questionAdapter.upsertMany(questions, state);
    }),
    on(questionActions.updateQuestion, (state, { update }) => {
      return questionAdapter.updateOne(update, state);
    }),
    on(questionActions.updateQuestions, (state, { updates }) => {
      return questionAdapter.updateMany(updates, state);
    }),
    on(questionActions.mapQuestion, (state, { entityMap }) => {
      return questionAdapter.mapOne(entityMap, state);
    }),
    on(questionActions.mapQuestions, (state, { entityMap }) => {
      return questionAdapter.map(entityMap, state);
    }),
    on(questionActions.deleteQuestion, (state, { id }) => {
      return questionAdapter.removeOne(id, state);
    }),
    on(questionActions.deleteQuestions, (state, { ids }) => {
      return questionAdapter.removeMany(ids, state);
    }),
    on(questionActions.deleteQuestionsByPredicate, (state, { predicate }) => {
      return questionAdapter.removeMany(predicate, state);
    }),
    on(questionActions.loadQuestions, (state, { questions }) => {
      return questionAdapter.setAll(questions, state);
    }),
    on(questionActions.setQuestions, (state, { questions }) => {
      return questionAdapter.setMany(questions, state);
    }),
    on(questionActions.clearQuestions, state => {
        return { ...state, Questions: questionAdapter.removeAll({ ...state, selectedQuestionId: undefined }) };
    })
  );
   
  export const getSelectedQuestionId = (state: QuestionState) => state.selectedQuestionId;
   
  // get the selectors
  const {
    selectIds,
    selectEntities,
    selectAll,
    selectTotal,
  } = questionAdapter.getSelectors();
   
  // select the array of question ids
  export const selectQuestionIds = selectIds;
   
  // select the dictionary of question entities
  export const selectQuestionEntities = selectEntities;
   
  // select the array of questions
  export const selectAllQuestions = selectAll;
   
  // select the total question count
  export const selectQuestionTotal = selectTotal;

/*

export const questionReducer = createReducer(
    initialQuestionState,
    on(actions.sessionQuestionActions.addQuestion, (state, { question }) => {
        return { ...state, Questions: questionAdapter.addOne(question, state) };
    }),
    on(actions.sessionQuestionActions.setQuestion, (state, { question }) => {
        return { ...state, Questions: questionAdapter.setOne(question, state) };
    }),
    on(actions.sessionQuestionActions.upsertQuestion, (state, { question }) => {
        return { ...state, Questions: questionAdapter.upsertOne(question, state) };
    }),
    on(actions.sessionQuestionActions.addQuestions, (state, { questions }) => {
        return { ...state, Questions: questionAdapter.addMany(questions, state) };
    }),
    on(actions.sessionQuestionActions.upsertQuestions, (state, { questions }) => {
        return { ...state, Questions: questionAdapter.upsertMany(questions, state) };
    }),
    on(actions.sessionQuestionActions.updateQuestion, (state, { update }) => {
        return { ...state, Questions: questionAdapter.updateOne(update, state) };
    }),
    on(actions.sessionQuestionActions.updateQuestions, (state, { updates }) => {
        return { ...state, Questions: questionAdapter.updateMany(updates, state) };
    }),
    on(actions.sessionQuestionActions.mapQuestion, (state, { entityMap }) => {
        return { ...state, Questions: questionAdapter.mapOne(entityMap, state) };
    }),
    on(actions.sessionQuestionActions.mapQuestions, (state, { entityMap }) => {
        return { ...state, Questions: questionAdapter.map(entityMap, state) };
    }),
    on(actions.sessionQuestionActions.deleteQuestion, (state, { id }) => {
        return { ...state, Questions: questionAdapter.removeOne(id, state) };
    }),
    on(actions.sessionQuestionActions.deleteQuestions, (state, { ids }) => {
        return { ...state, Questions: questionAdapter.removeMany(ids, state) };
    }),
    on(actions.sessionQuestionActions.deleteQuestionsByPredicate, (state, { predicate }) => {
        return { ...state, Questions: questionAdapter.removeMany(predicate, state) };
    }),
    on(actions.sessionQuestionActions.loadQuestions, (state, { questions }) => {
        return { ...state, Questions: questionAdapter.setAll(questions, state) };
    }),
    on(actions.sessionQuestionActions.setQuestions, (state, { questions }) => {
        return { ...state, Questions: questionAdapter.setMany(questions, state) };
    }),
    on(actions.sessionQuestionActions.clearQuestions, state => {
        return { ...state, Questions: questionAdapter.removeAll({ ...state, selectedQuestionId: undefined }) };
    })
);

export const getSelectedQuestionId = (state: QuestionState) => state.selectedQuestionId;

// get the selectors
const {
    selectIds,
    selectEntities,
    selectAll,
    selectTotal,
} = questionAdapter.getSelectors();

// select the array of question ids
export const selectQuestionIds = selectIds;

// select the dictionary of question entities
export const selectQuestionEntities = selectEntities;

// select the array of questions
export const selectAllQuestions = selectAll;

// select the total question count
export const selectQuestionTotal = selectTotal;
*/
