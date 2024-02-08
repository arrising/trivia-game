import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { GameInstance } from '../models/game';
import { games } from './games';
import { Question } from '../models/question';
import { RoundInstance } from '../models/round';
import { CategoryInstance } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private _gameData: Array<GameInstance>;
  private _roundData: Array<RoundInstance>;
  private _categoryData: Array<CategoryInstance>;
  private _questionData: Array<Question>;

  constructor() {
    this._gameData = games.map(game => ({
      ...game,
      roundIds: game.rounds.map(round => round.id)
    }));

    this._roundData = games.map(game => game.rounds).flat()
      .map(round => ({
        ...round,
        categoryIds: round.categoryies.map(category => category.id)
      }));

    this._categoryData = games.map(game => game.rounds).flat()
      .map(round => round.categoryies).flat()
      .map(category => ({
        ...category,
        questions: category.questions.map(question => ({
          questionId: question.id,
          value: question.value
        }))
      }));

    this._questionData = games.map(x => x.rounds).flat()
      .map(x => x.categoryies).flat()
      .map(x => x.questions).flat();
  }

  getAllGames(): Observable<Array<GameInstance>> {
    return of(this._gameData);
  }

  getGame(gameId: string): Observable<GameInstance | undefined> {
    return of(this._gameData.find(x => x.id == gameId));
  }

  getCategories(catrgoryIds: Array<string>): Observable<Array<CategoryInstance> | undefined> {
    return of(this._categoryData.filter(x => catrgoryIds.includes(x.id)));
  }

  getRound(roundId: string): Observable<RoundInstance | undefined> {
    return of(this._roundData.find(round => round.id == roundId));
  }

  getRounds(roundIds: Array<string>): Observable<Array<RoundInstance> | undefined> {
    return of(this._roundData.filter(x => roundIds.includes(x.id)));
  }

  getQuestion(questionId: string): Observable<Question | undefined> {
    return of(this._questionData.find(x => x.id == questionId));
  }

  getQuestions(questionIds: Array<string>): Observable<Array<Question> | undefined> {
    return of(this._questionData.filter(x => questionIds.includes(x.id)));
  }
}
