import { createAction, props } from '@ngrx/store';
import { game } from 'src/app/models/game';

export enum GameActionType {
  LoadGame = '[Game Play] Load Game',
  GameLoaded = '[Game Play] Game Loaded',
  GameLoadError = '[Game Play] Error Loading Game'
}

export const loadGame = createAction(GameActionType.LoadGame, props<{ gameId: string; }>());
export const gameLoaded = createAction(GameActionType.GameLoaded, props<{ game: game; }>());
export const gameLoadError = createAction(GameActionType.GameLoadError, props<{ error: any; }>());
