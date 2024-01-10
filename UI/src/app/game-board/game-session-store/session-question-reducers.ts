import { createReducer, on } from '@ngrx/store';
import { QuestionState, questionAdapter, initialState } from './game-session-state';
import * as actions from './session-question-actions';

export const questionReducer = createReducer(
    initialState,
    on(actions.sessionQuestionActions.addQuestion, (state, { question }) => {
        return { ...state, Questions: questionAdapter.addOne(question, state.Questions) };
    }),
    on(actions.sessionQuestionActions.setQuestion, (state, { question }) => {
        return { ...state, Questions: questionAdapter.setOne(question, state.Questions) };
    }),
    on(actions.sessionQuestionActions.upsertQuestion, (state, { question }) => {
        return { ...state, Questions: questionAdapter.upsertOne(question, state.Questions) };
    }),
    on(actions.sessionQuestionActions.addQuestions, (state, { questions }) => {
        return { ...state, Questions: questionAdapter.addMany(questions, state.Questions) };
    }),
    on(actions.sessionQuestionActions.upsertQuestions, (state, { questions }) => {
        return { ...state, Questions: questionAdapter.upsertMany(questions, state.Questions) };
    }),
    on(actions.sessionQuestionActions.updateQuestion, (state, { update }) => {
        return { ...state, Questions: questionAdapter.updateOne(update, state.Questions) };
    }),
    on(actions.sessionQuestionActions.updateQuestions, (state, { updates }) => {
        return { ...state, Questions: questionAdapter.updateMany(updates, state.Questions) };
    }),
    on(actions.sessionQuestionActions.mapQuestion, (state, { entityMap }) => {
        return { ...state, Questions: questionAdapter.mapOne(entityMap, state.Questions) };
    }),
    on(actions.sessionQuestionActions.mapQuestions, (state, { entityMap }) => {
        return { ...state, Questions: questionAdapter.map(entityMap, state.Questions) };
    }),
    on(actions.sessionQuestionActions.deleteQuestion, (state, { id }) => {
        return { ...state, Questions: questionAdapter.removeOne(id, state.Questions) };
    }),
    on(actions.sessionQuestionActions.deleteQuestions, (state, { ids }) => {
        return { ...state, Questions: questionAdapter.removeMany(ids, state.Questions) };
    }),
    on(actions.sessionQuestionActions.deleteQuestionsByPredicate, (state, { predicate }) => {
        return { ...state, Questions: questionAdapter.removeMany(predicate, state.Questions) };
    }),
    on(actions.sessionQuestionActions.loadQuestions, (state, { questions }) => {
        return { ...state, Questions: questionAdapter.setAll(questions, state.Questions) };
    }),
    on(actions.sessionQuestionActions.setQuestions, (state, { questions }) => {
        return { ...state, Questions: questionAdapter.setMany(questions, state.Questions) };
    }),
    on(actions.sessionQuestionActions.clearQuestions, state => {
        return { ...state, Questions: questionAdapter.removeAll({ ...state.Questions, selectedQuestionId: undefined }) };
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
