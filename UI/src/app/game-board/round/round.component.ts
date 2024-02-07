import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { Game } from 'src/app/models/game';
import { SessionRound } from '../game-store/game-round-store/game-round-state';
import * as sessionStore from '../game-store';

@Component({
  selector: 'app-round',
  templateUrl: './round.component.html',
  styleUrls: ['./round.component.scss']
})
export class RoundComponent {
  currentGame$: Observable<Game | undefined> = of(undefined);
  currentRound$: Observable<SessionRound | undefined> = of(undefined);
  
  constructor(private _store: Store) { 
  }

  ngOnInit(): void {
    this.currentGame$ = this._store.select(sessionStore.game.selectors.getSelectedGame);
    this.currentRound$ = this._store.select(sessionStore.rounds.selectors.getSelectedRound);
  }

  viewQuestion(questionId: string): void {
    this._store.dispatch(sessionStore.game.actions.selectQuestion({ questionId }));
  }
}
