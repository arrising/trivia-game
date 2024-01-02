import { Component, Input } from '@angular/core';
import { GameService } from '../data/game.service';
import { game } from '../models/game';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-game-board',
  templateUrl: './game-board.component.html',
  styleUrls: ['./game-board.component.scss']
})
export class GameBoardComponent {
  private _gameId: string = '';
  @Input() set gameId(value: string){
    this._gameId = value;
    this.currentGame$ = this._service.getGame(value);
  }
  get gameId() {
    return this._gameId;
  }

  currentGame$: Observable<game | undefined> = of(undefined); 

  constructor(private _service: GameService) {
  }
}
