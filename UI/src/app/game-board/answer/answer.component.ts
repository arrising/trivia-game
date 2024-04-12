import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { GameService } from 'src/app/data/game.service';
import { SessionQuestion } from '../game-store/game-question-store/game-question-state';
import * as sessionStore from '../game-store';

@Component({
  selector: 'app-answer',
  templateUrl: './answer.component.html',
  styleUrls: ['./answer.component.scss']
})
export class AnswerComponent {
  currentQuestion$: Observable<SessionQuestion | undefined>;

  constructor(private _store: Store, private _service: GameService) {
    this.currentQuestion$ = this._store.select(sessionStore.questions.selectors.getSelectedQuestion);}
  
  viewRound(): void {
    this._store.dispatch(sessionStore.game.actions.showRound());
  }
}
