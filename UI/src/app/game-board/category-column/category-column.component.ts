import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import * as sessionStore from '../game-store';
import { SessionCategory } from '../game-store/game-category-store/game-category-state';

@Component({
  selector: 'app-category-column',
  templateUrl: './category-column.component.html',
  styleUrls: ['./category-column.component.scss']
})
export class CategoryColumnComponent {
  private _categoryId: string = '';
  @Input() set categoryId(value: string) {
    this._categoryId = value;
    this.currentCategory$ = this._store.select(sessionStore.category.selectors.getCategory({id: value}));
  }
  get categoryId() {
    return this._categoryId;
  }
  
  currentCategory$: Observable<SessionCategory | undefined> = of(undefined);

  constructor(private _store: Store) {
  }
}
