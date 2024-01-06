import { question } from 'src/app/models/question';
import { currentGame } from '../game-models/current-game';

export interface GameState {
    currentGame: currentGame | undefined;
    questions: Array<question>;
  }
  
  export const initialGameState: GameState = {
    currentGame: undefined,
    questions: []
  };
