import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GameInstance } from '../models/game';
import { RoundInstance } from '../models/round';
import { CategoryInstance } from '../models/category';
import { environment } from 'src/environments/environment';
import { SessionQuestion } from '../game-board/game-store/game-question-store/game-question-state';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private _baseUrl: string;
  private _gameUrl: string;
  private _roundUrl: string;
  private _categoryUrl: string;
  private _questionUrl: string;

  constructor(private _http: HttpClient,) {
    this._baseUrl = environment.apiUrl;
    this._gameUrl = `${this._baseUrl}/api/games`;
    this._roundUrl = `${this._baseUrl}/api/rounds`;
    this._categoryUrl = `${this._baseUrl}/api/categories`;
    this._questionUrl = `${this._baseUrl}/api/questions`;
  }

  getAllGames(): Observable<Array<GameInstance>> {
    return this._http.get<GameInstance[]>(this._gameUrl);
  }

  getGame(gameId: string): Observable<GameInstance | undefined> {
    return this._http.get<GameInstance>(`${this._gameUrl}/${gameId}`);
  }

  getCategories(roundId: string): Observable<Array<CategoryInstance> | undefined> {
    return this._http.get<Array<CategoryInstance>>(`${this._categoryUrl}/byRoundId/${roundId}`);
  }

  getRound(roundId: string): Observable<RoundInstance | undefined> {
    return this._http.get<RoundInstance>(`${this._roundUrl}/${roundId}`);
  }

  getRounds(gameId: string): Observable<Array<RoundInstance> | undefined> {
    return this._http.get<Array<RoundInstance>>(`${this._roundUrl}/byGameId/${gameId}`);
  }

  getQuestion(questionId: string): Observable<SessionQuestion | undefined> {
    return this._http.get<SessionQuestion>(`${this._questionUrl}/${questionId}`);
  }

  getQuestions(categoryId: string): Observable<Array<SessionQuestion> | undefined> {
    return this._http.get<Array<SessionQuestion>>(`${this._questionUrl}/byCategoryId/${categoryId}`);
  }
}
