import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { GameInstance } from '../models/game';
import { games } from './games';
import { Question } from '../models/question';
import { RoundInstance } from '../models/round';
import { CategoryInstance } from '../models/category';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private _baseUrl: string;
  private _gameUrl: string;
  private _roundUrl: string;
  private _categoryUrl: string;
  private _questionUrl: string;

  private _gameData: Array<GameInstance>;
  private _roundData: Array<RoundInstance>;
  private _categoryData: Array<CategoryInstance>;
  private _questionData: Array<Question>;

  constructor(private _http: HttpClient,) {
    this._baseUrl = environment.apiUrl;
    this._gameUrl = `${this._baseUrl}/api/games`;
    this._roundUrl = `${this._baseUrl}/api/rounds`;
    this._categoryUrl = `${this._baseUrl}/api/categories`;
    this._questionUrl = `${this._baseUrl}/api/questions`;

    this._gameData = [];
    this._roundData = [];
    this._categoryData = [];
    this._questionData = [];

    /*
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
    */
  }

  getAllGames(): Observable<Array<GameInstance>> {
    return this._http.get<GameInstance[]>(this._gameUrl);
  }

  getGame(gameId: string): Observable<GameInstance | undefined> {
    return this._http.get<GameInstance>(`${this._gameUrl}/${gameId}`);
  }

  getCategories(catrgoryIds: Array<string>): Observable<Array<CategoryInstance> | undefined> {
    /*
    var categories = this._http.get<Array<CategoryInstance>>(`${this._categoryUrl}/byRoundId${roundId}`);
    console.log('getCategories', { categories });
    return categories;*/
    return of(this._categoryData.filter(x => catrgoryIds.includes(x.id)));
  }

  getRounds(gameId: string): Observable<Array<RoundInstance> | undefined> {
    return this._http.get<Array<RoundInstance>>(`${this._roundUrl}/byGameId/${gameId}`);
  }

  getQuestion(questionId: string): Observable<Question | undefined> {
    return of(this._questionData.find(x => x.id == questionId));
  }

  getQuestions(questionIds: Array<string>): Observable<Array<Question> | undefined> {
    return of(this._questionData.filter(x => questionIds.includes(x.id)));
  }
}
