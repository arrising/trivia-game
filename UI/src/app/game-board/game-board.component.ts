import { Component, Input } from '@angular/core';
import { GameService } from '../data/game.service';
import { Game } from '../models/game';
import { Observable, of } from 'rxjs';
import { Store } from '@ngrx/store';
import * as sessionStore from './game-store';
import { SessionRound } from './game-store/game-round-store/game-round-state';

@Component({
  selector: 'app-game-board',
  templateUrl: './game-board.component.html',
  styleUrls: ['./game-board.component.scss']
})
export class GameBoardComponent {
  currentGame$: Observable<Game | undefined> = of(undefined);
  gameRounds$: Observable< Array<SessionRound> | undefined> = of(undefined);

  constructor(private _store: Store, private _service: GameService) { }

  ngOnInit(): void {
    this.currentGame$ = this._store.select(sessionStore.game.selectors.getSelectedGame);
    this.gameRounds$ = this._store.select(sessionStore.rounds.selectors.selectAllRounds);
  }

  loadRound(roundId: string): void {
    this._store.dispatch(sessionStore.game.actions.selectRound({ roundId }));
  }
}
