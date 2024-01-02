import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ModeSelectorComponent } from './mode-selector/mode-selector.component';
import { GameBoardComponent } from './game-board/game-board.component';
import { GameSelectorComponent } from './game-selector/game-selector.component';
import { RoundComponent } from './game-board/round/round.component';
import { QuestionComponent } from './game-board/question/question.component';
import { AnswerComponent } from './game-board/answer/answer.component';

const routes: Routes = [
  { path: '',   redirectTo: '/selector', pathMatch: 'full' },
  { path: 'selector', component: ModeSelectorComponent },
  { path: 'games', component: GameSelectorComponent },
  { path: 'game/:gameId', component: GameBoardComponent },
  { path: 'game/:gameId/round/:roundId', component: RoundComponent },
  { path: 'game/:gameId/round/:roundId/question/:questionId', component: QuestionComponent },
  { path: 'game/:gameId/round/:roundId/question/:questionId/answer', component: AnswerComponent },
];
const routeOptions = {
  bindToComponentInputs: true
};

@NgModule({
  imports: [RouterModule.forRoot(routes, routeOptions)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
