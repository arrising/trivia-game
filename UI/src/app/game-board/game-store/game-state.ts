import { game } from 'src/app/models/game';
import { question } from 'src/app/models/question';

export interface GameState {
    currentGame: game | undefined;
    questions: Array<question>;
  }
  
  export const initialGameState: GameState = {
    currentGame: undefined,
    questions: []
  };
