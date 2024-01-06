import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { GameService } from 'src/app/data/game.service';
import { game } from 'src/app/models/game';
import { gameRound } from 'src/app/models/game-round';
import * as gameStore from '../game-store';

@Component({
  selector: 'app-round',
  templateUrl: './round.component.html',
  styleUrls: ['./round.component.scss']
})
export class RoundComponent {
  private _gameId: string = '';
  @Input() set gameId(value: string) {
    this._gameId = value;
    this.currentGame$ = this._service.getGame(value);
  }
  get gameId() {
    return this._gameId;
  }

  private _roundId: string = '';
  @Input() set roundId(value: string) {
    this._roundId = value;
    this.currentRound$ = this._service.getRound(this._gameId, value);
  }
  get roundId() {
    return this._roundId;
  }

  currentGame$: Observable<game | undefined> = of(undefined);
  currentRound$: Observable<gameRound | undefined> = of(undefined);
  constructor(private _store: Store, private _service: GameService) { }

  viewQuestion(gameId: string, roundId: string, questionId: string): void {
    this._store.dispatch(gameStore.actions.viewQuestion({ gameId, roundId, questionId }));
  }
}
