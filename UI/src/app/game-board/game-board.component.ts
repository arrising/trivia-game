import { Component, Input } from '@angular/core';
import { GameService } from '../data/game.service';
import { Game } from '../models/game';
import { Observable, of } from 'rxjs';
import { Store } from '@ngrx/store';
import * as sessionStore from './game-store';

@Component({
  selector: 'app-game-board',
  templateUrl: './game-board.component.html',
  styleUrls: ['./game-board.component.scss']
})
export class GameBoardComponent {
  private _gameId: string = '';
  @Input() set gameId(value: string) {
    this._gameId = value;
    this.currentGame$ = this._service.getGame(value);
  }
  get gameId() {
    return this._gameId;
  }

  currentGame$: Observable<Game | undefined> = of(undefined);

  constructor(private _store: Store, private _service: GameService) { }

  loadRound(gameId: string, roundId: string): void {
    this._store.dispatch(sessionStore.game.actions.selectRound({ roundId }));
  }
}
