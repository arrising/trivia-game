import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import * as sessionStore from '../../game-session-store';

@Component({
  selector: 'app-game-select-button',
  templateUrl: './game-select-button.component.html',
  styleUrls: ['./game-select-button.component.scss']
})
export class GameSelectButtonComponent {

  constructor(private _store: Store) { }

  onCLick(): void {
    this._store.dispatch(sessionStore.actions.navigation.viewGameSelector());
  }
}
