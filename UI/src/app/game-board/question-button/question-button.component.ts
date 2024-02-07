import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { Game } from 'src/app/models/game';
import * as sessionStore from '../game-store';
import { SessionQuestion } from '../game-store/game-question-store/game-question-state';

@Component({
  selector: 'app-question-button',
  templateUrl: './question-button.component.html',
  styleUrls: ['./question-button.component.scss']
})
export class QuestionButtonComponent {
  private _questionId: string = '';
  @Input() set questionId(value: string) {
    this._questionId = value;
    this.currentQuestion$ = this._store.select(sessionStore.questions.selectors.getQuestion({id: value}));
  }
  get questionId() {
    return this._questionId;
  }
  
  currentGame$: Observable<Game | undefined> = of(undefined);
  currentQuestion$: Observable<SessionQuestion | undefined> = of(undefined);

  constructor(private _store: Store) {
  }

  ngOnInit(): void {
    this.currentGame$ = this._store.select(sessionStore.game.selectors.getSelectedGame);
  }

  viewQuestion(questionId: string): void {
    this._store.dispatch(sessionStore.game.actions.selectQuestion({ questionId }));
  }
}
