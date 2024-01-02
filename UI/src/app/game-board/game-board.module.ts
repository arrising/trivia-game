import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameBoardComponent } from './game-board.component';
import { RouterModule } from '@angular/router';
import { RoundComponent } from './round/round.component';
import { QuestionComponent } from './question/question.component';
import { AnswerComponent } from './answer/answer.component';
import { StoreModule } from '@ngrx/store';
import * as fromGameStore from './game-store/index'; 

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
    StoreModule.forFeature(fromGameStore.featureKey, fromGameStore.reducers),
  ],
  exports: [
    GameBoardComponent,
    RoundComponent,
    QuestionComponent,
    AnswerComponent
  ]
})
export class GameBoardModule { }
