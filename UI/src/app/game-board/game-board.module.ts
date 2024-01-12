import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LayoutModule } from '../layout/layout.module';
import { GameBoardComponent } from './game-board.component';
import { GameSelectorComponent } from './game-selector/game-selector.component';
import { RoundComponent } from './round/round.component';
import { QuestionComponent } from './question/question.component';
import { AnswerComponent } from './answer/answer.component';
import { GameControlsModule } from './game-controls/game-controls.module';
import { GameStoreModule } from './game-store/game-store.module';

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
    LayoutModule,
    GameControlsModule
,
GameStoreModule  ],
  exports: [
    GameBoardComponent,
    RoundComponent,
    QuestionComponent,
    AnswerComponent
  ]
})
export class GameBoardModule { }
