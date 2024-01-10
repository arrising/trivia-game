import { Question } from 'src/app/models/question';
import { currentGame } from '../game-models/current-game';
import { EntityState } from '@ngrx/entity';


export interface QuestionsData extends EntityState<Question> {
  selectedQuestionId?: string ;
}


export interface GameState {
    currentGame: currentGame | undefined;
    questions: Array<Question>;
  }
  
  export const initialGameState: GameState = {
    currentGame: undefined,
    questions: []
  };
