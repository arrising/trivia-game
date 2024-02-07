import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { GameService } from 'src/app/data/game.service';
import * as sessionStore from '../game-store';
import { SessionQuestion } from '../game-store/game-question-store/game-question-state';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent {
  currentQuestion$: Observable<SessionQuestion | undefined> = of(undefined);

  constructor(private _store: Store, private _service: GameService) { }

  ngOnInit(): void {
    this.currentQuestion$ = this._store.select(sessionStore.questions.selectors.getSelectedQuestion);
  }

  viewAnswer(): void {
    this._store.dispatch(sessionStore.game.actions.showAnswer());
  }
  
  viewRound(): void {
    this._store.dispatch( sessionStore.game.actions.showRound());
  }
}
