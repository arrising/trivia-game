import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Game } from '../models/game';
import { games } from './games';
import { Question } from '../models/question';
import { questions } from './questions';
import { categories } from './categories';
import { GameRound } from '../models/game-round';
import { GameCategory } from '../models/game-category';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor() { }

  getAllGames(): Observable<Array<Game>> {
    return of(games);
  }

  getGame(gameId: string): Observable<Game | undefined> {
    return of(games.find(x => x.id == gameId));
  }

  getCategories(catrgoryIds: Array<string>): Observable<Array<GameCategory> | undefined> {
    return of(categories.filter(x => catrgoryIds.includes(x.id)));
  }

  getRound(gameId: string, roundId: string): Observable<GameRound | undefined> {
    return of(games.find(x => x.id == gameId)?.rounds.find(round => round.id == roundId));
  }

  getQuestion(questionId: string): Observable<Question | undefined> {
    return of(questions.find(x => x.id == questionId));
  }

  getQuestions(questionIds: Array<string>): Observable<Array<Question> | undefined> {
    return of(questions.filter(x => questionIds.includes(x.id)));
  }
}
