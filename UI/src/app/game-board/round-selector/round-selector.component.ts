import { Component } from '@angular/core';
import { Game } from '../../models/game';
import { Observable, of } from 'rxjs';
import { Store } from '@ngrx/store';
import * as sessionStore from '../game-store';
import { SessionRound } from '../game-store/game-round-store/game-round-state';

@Component({
  selector: 'app-round-selector',
  templateUrl: './round-selector.component.html',
  styleUrls: ['./round-selector.component.scss']
})
export class RoundSelectorComponent {
  currentGame$: Observable<Game | undefined> = of(undefined);
  gameRounds$: Observable< Array<SessionRound> | undefined> = of(undefined);

  constructor(private _store: Store) { }

  ngOnInit(): void {
    this.currentGame$ = this._store.select(sessionStore.game.selectors.getSelectedGame);
    this.gameRounds$ = this._store.select(sessionStore.rounds.selectors.selectAllRounds);
  }

  loadRound(roundId: string): void {
    this._store.dispatch(sessionStore.rounds.actions.selectRound({ roundId }));
  }
}
