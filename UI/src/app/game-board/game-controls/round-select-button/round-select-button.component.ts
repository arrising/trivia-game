import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import * as sessionStore from '../../game-store';

@Component({
  selector: 'app-round-select-button',
  templateUrl: './round-select-button.component.html',
  styleUrls: ['./round-select-button.component.scss']
})
export class RoundSelectButtonComponent {

  constructor(private _store: Store) {}
  onCLick(): void {
    this._store.dispatch(sessionStore.navigation.actions.viewRoundSelector());
  }
}
