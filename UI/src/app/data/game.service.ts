import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { game } from '../models/game';
import { games } from './games';
import { question } from '../models/question';
import { questions } from './questions';
import { gameRound } from '../models/game-round';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor() { }

  getAllGames(): Observable<Array<game>> {
    return of(games);
  }

  getGame(gameId: string): Observable<game | undefined> {
    return of(games.find(x => x.id == gameId));
  }

  getRound(gameId: string, roundId: string): Observable<gameRound | undefined> {
    return of(games.find(x => x.id == gameId)?.rounds.find(round => round.id == roundId));
  }

  getQuestion(questionId: string): Observable<question | undefined> {
    return of(questions.find(x => x.id == questionId));
  }
}
