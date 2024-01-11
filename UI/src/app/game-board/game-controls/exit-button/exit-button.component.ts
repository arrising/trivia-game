import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import * as sessionStore from '../../game-store';

@Component({
  selector: 'app-exit-button',
  templateUrl: './exit-button.component.html',
  styleUrls: ['./exit-button.component.scss']
})
export class ExitButtonComponent {

  constructor(private _store: Store) { }

  onCLick(): void {
    this._store.dispatch(sessionStore.navigation.actions.exitGames());
  }
}
