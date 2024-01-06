import { Component } from '@angular/core';
import { GameService } from '../../data/game.service';
import { game } from '../../models/game';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import * as gameStore from '../game-store';

@Component({
  selector: 'app-game-selector',
  templateUrl: './game-selector.component.html',
  styleUrls: ['./game-selector.component.scss']
})
export class GameSelectorComponent {
  allGames: Observable<Array<game>>;

  constructor(private _store: Store, private _service: GameService) {
    this.allGames = this._service.getAllGames();
  }

  loadGame(gameId: string): void {
    this._store.dispatch(gameStore.actions.loadGame({ gameId }));
  }
}