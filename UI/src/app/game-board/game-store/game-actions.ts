import { createAction, props } from '@ngrx/store';
import { game } from 'src/app/models/game';

export enum GameActionType {
  LoadGame = '[GameBoard Load Game] Load Game',
  GameLoaded = '[GameBoard Game Loaded] Game Loaded',
  GameLoadError = '[GameBoard Load Error] Error Loading Game',
  StartRound = '[GameBoard Start Round] Start Round',
  ViewRound = '[GameBoard View Round] View Round',
  ViewQuestion = '[GameBoard View Question] View question',
  ViewAnswer = '[GameBoard View Answer] View Answer'
}

export const loadGame = createAction(GameActionType.LoadGame, props<{ gameId: string; }>());
export const gameLoaded = createAction(GameActionType.GameLoaded, props<{ game: game; }>());
export const gameLoadError = createAction(GameActionType.GameLoadError, props<{ error: any; }>());
export const startRound = createAction(GameActionType.StartRound, props<{ gameId: string, roundId: string; }>());
export const viewRound = createAction(GameActionType.ViewRound, props<{ gameId: string, roundId: string; }>());
export const viewQuestion = createAction(GameActionType.ViewQuestion, props<{ gameId: string, roundId: string, questionId: string; }>());
export const viewAnswer = createAction(GameActionType.ViewAnswer, props<{ gameId: string, roundId: string, questionId: string; }>());
