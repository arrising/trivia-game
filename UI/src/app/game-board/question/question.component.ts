import { Component, Input } from '@angular/core';
import { Observable, of } from 'rxjs';
import { GameService } from 'src/app/data/game.service';
import { question } from 'src/app/models/question';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent {
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

  currentQuestion$: Observable<question | undefined> = of(undefined); 
  constructor(private _service: GameService) {
  }
}
