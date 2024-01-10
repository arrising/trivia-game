import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { GameService } from 'src/app/data/game.service';
import { Question } from 'src/app/models/question';
import * as gameStore from '../game-store';

@Component({
  selector: 'app-answer',
  templateUrl: './answer.component.html',
  styleUrls: ['./answer.component.scss']
})
export class AnswerComponent {
  private _gameId: string = '';
  @Input() set gameId(value: string){
    this._gameId = value;
  }
  get gameId() {
    return this._gameId;
  }

  private _roundId: string = '';
  @Input() set roundId(value: string){
    this._roundId = value;
  }
  get roundId() {
    return this._roundId;
  }

  private _questionId: string = '';
  @Input() set questionId(value: string){
    this._questionId = value;
    this.currentQuestion$ = this._service.getQuestion(value);
  }
  get questionId() {
    return this._questionId;
  }

  currentQuestion$: Observable<Question | undefined> = of(undefined); 
  constructor(private _store: Store, private _service: GameService) {}
  
  viewRound(gameId: string, roundId: string): void {
    this._store.dispatch(gameStore.actions.viewRound({ gameId, roundId }))
  }
}
