import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { StoreModule } from '@ngrx/store';
import { LayoutModule } from '../layout/layout.module';
import { GameBoardComponent } from './game-board.component';
import { GameSelectorComponent } from './game-selector/game-selector.component';
import { RoundComponent } from './round/round.component';
import { QuestionComponent } from './question/question.component';
import { AnswerComponent } from './answer/answer.component';
import { EffectsModule } from '@ngrx/effects';
import { GameControlsModule } from './game-controls/game-controls.module';
import * as gameStore from './game-store/index';
import * as gameSessionStore from './game-session-store';

const gameBoardRoutes: Routes = [
  { path: 'games', component: GameSelectorComponent },
  { path: 'games/game/:gameId', component: GameBoardComponent },
  { path: 'games/game/:gameId/round/:roundId', component: RoundComponent },
  { path: 'games/game/:gameId/round/:roundId/question/:questionId', component: QuestionComponent },
  { path: 'games/game/:gameId/round/:roundId/question/:questionId/answer', component: AnswerComponent },
];

@NgModule({
  declarations: [
    GameBoardComponent,
    GameSelectorComponent,
    RoundComponent,
    QuestionComponent,
    AnswerComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    RouterModule.forChild(gameBoardRoutes),
    StoreModule.forFeature(gameStore.featureKey, gameStore.reducers),
    EffectsModule.forFeature(gameStore.effects),
    StoreModule.forFeature(gameSessionStore.featureKey, gameSessionStore.reducers),
    EffectsModule.forFeature([
      gameSessionStore.effects.questions
    ]),
    EffectsModule.forFeature([
      gameSessionStore.effects.navigation
    ]),
    LayoutModule,
    GameControlsModule
  ],
  exports: [
    GameBoardComponent,
    RoundComponent,
    QuestionComponent,
    AnswerComponent
  ]
})
export class GameBoardModule { }
