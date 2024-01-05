import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameBoardComponent } from './game-board.component';
import { RouterModule, Routes } from '@angular/router';
import { RoundComponent } from './round/round.component';
import { QuestionComponent } from './question/question.component';
import { AnswerComponent } from './answer/answer.component';
import { StoreModule } from '@ngrx/store';
import * as fromGameStore from './game-store/index'; 
import { LayoutModule } from '../layout/layout.module';

const gameBoardRoutes: Routes = [
  { path: 'game/:gameId', component: GameBoardComponent },
  { path: 'game/:gameId/round/:roundId', component: RoundComponent },
  { path: 'game/:gameId/round/:roundId/question/:questionId', component: QuestionComponent },
  { path: 'game/:gameId/round/:roundId/question/:questionId/answer', component: AnswerComponent },
];

@NgModule({
  declarations: [
    GameBoardComponent,
    RoundComponent,
    QuestionComponent,
    AnswerComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    RouterModule.forChild(gameBoardRoutes),
    StoreModule.forFeature(fromGameStore.featureKey, fromGameStore.reducers),
    LayoutModule
  ],
  exports: [
    GameBoardComponent,
    RoundComponent,
    QuestionComponent,
    AnswerComponent
  ]
})
export class GameBoardModule { }
