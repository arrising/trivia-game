import { game } from 'src/app/models/game';
import * as gameActions from './game-actions';
import * as gameReducers from './game-reducers';
import { question } from 'src/app/models/question';

export const featureKey = 'gameBoard';

export interface GameState {
    currentGame: game | undefined;
    questions: Array<question>;
  }

  export const initialGameState: GameState = {
    currentGame: undefined,
    questions: []
  };

  export const ActionType = gameActions.GameActionType;
  export const actions = gameActions;
  export const reducer = gameReducers.reducer;

export const fromGameStore = {
    actions: gameActions,
    reducer: gameReducers.reducer
}
