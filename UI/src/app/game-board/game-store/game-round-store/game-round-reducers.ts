import { createReducer, on } from '@ngrx/store';
import { RoundState, initialRoundState, roundAdapter } from './game-round-state';
import { sessionRoundActions as roundActions } from './game-round-actions';

export const roundReducer = createReducer(
  initialRoundState,
  on(roundActions.addRound, (state, { round }) => {
    return roundAdapter.addOne(round, state)
  }),
  on(roundActions.setRound, (state, { round }) => {
    return roundAdapter.setOne(round, state)
  }),
  on(roundActions.upsertRound, (state, { round }) => {
    return roundAdapter.upsertOne(round, state);
  }),
  on(roundActions.addRounds, (state, { rounds }) => {
    return roundAdapter.addMany(rounds, state);
  }),
  on(roundActions.upsertRounds, (state, { rounds }) => {
    return roundAdapter.upsertMany(rounds, state);
  }),
  on(roundActions.updateRound, (state, { update }) => {
    return roundAdapter.updateOne(update, state);
  }),
  on(roundActions.updateRounds, (state, { updates }) => {
    return roundAdapter.updateMany(updates, state);
  }),
  on(roundActions.mapRound, (state, { entityMap }) => {
    return roundAdapter.mapOne(entityMap, state);
  }),
  on(roundActions.mapRounds, (state, { entityMap }) => {
    return roundAdapter.map(entityMap, state);
  }),
  on(roundActions.deleteRound, (state, { id }) => {
    return roundAdapter.removeOne(id, state);
  }),
  on(roundActions.deleteRounds, (state, { ids }) => {
    return roundAdapter.removeMany(ids, state);
  }),
  on(roundActions.deleteRoundsByPredicate, (state, { predicate }) => {
    return roundAdapter.removeMany(predicate, state);
  }),
  on(roundActions.loadRounds, (state, { rounds }) => {
    return roundAdapter.setAll(rounds, state);
  }),
  on(roundActions.setRounds, (state, { rounds }) => {
    return roundAdapter.setMany(rounds, state);
  }),
  on(roundActions.clearRounds, state => {
    return { ...state, Rounds: roundAdapter.removeAll({ ...state, selectedRoundId: undefined }) };
  }),
  on(roundActions.setSelectedRound, (state, { id }) => ({
    ...state,
    selectedRoundId: id
  }))
);

// get the selectors
const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = roundAdapter.getSelectors();

// select the array of round ids
export const selectRoundIds = selectIds;

// select the dictionary of round entities
export const selectRoundEntities = selectEntities;

// select the array of rounds
export const selectAllRounds = selectAll;

// select the total round count
export const selectRoundTotal = selectTotal;
