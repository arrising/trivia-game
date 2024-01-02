import { Component } from '@angular/core';
import { GameService } from '../data/game.service';
import { game } from '../models/game';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-game-selector',
  templateUrl: './game-selector.component.html',
  styleUrls: ['./game-selector.component.scss']
})
export class GameSelectorComponent {
  allGames: Observable<Array<game>>;

  constructor(private service: GameService) {
    this.allGames = service.getAllGames();
  }
}