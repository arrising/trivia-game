import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LayoutModule } from '../layout/layout.module';
import { GameSelectorComponent } from './game-selector/game-selector.component';
import { RoundComponent } from './round/round.component';
import { RoundSelectorComponent } from './round-selector/round-selector.component';
import { QuestionComponent } from './question/question.component';
import { AnswerComponent } from './answer/answer.component';
import { GameControlsModule } from './game-controls/game-controls.module';
import { GameStoreModule } from './game-store/game-store.module';
import { QuestionButtonComponent } from './question-button/question-button.component';
import { CategoryColumnComponent } from './category-column/category-column.component';
import { gameLoadedGuard } from './guards/game-loaded.guard';

const gameBoardRoutes: Routes = [
  { path: 'games', component: GameSelectorComponent },
  {
    path: 'games/game/:gameId',
    component: RoundSelectorComponent,
    canActivate: [gameLoadedGuard]
  },
  {
    path: 'games/game/:gameId/round/:roundId',
    component: RoundComponent,
    canActivate: [gameLoadedGuard]
  },
  {
    path: 'games/game/:gameId/round/:roundId/question/:questionId',
    component: QuestionComponent,
    canActivate: [gameLoadedGuard]
  },
  {
    path: 'games/game/:gameId/round/:roundId/question/:questionId/answer',
    component: AnswerComponent,
    canActivate: [gameLoadedGuard]
  },
];

@NgModule({
  declarations: [
    GameSelectorComponent,
    RoundComponent,
    RoundSelectorComponent,
    QuestionComponent,
    AnswerComponent,
    QuestionButtonComponent,
    CategoryColumnComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    RouterModule.forChild(gameBoardRoutes),
    LayoutModule,
    GameControlsModule,
    GameStoreModule
  ],
  exports: [
    RoundComponent,
    RoundSelectorComponent,
    QuestionComponent,
    AnswerComponent
  ]
})
export class GameBoardModule { }
