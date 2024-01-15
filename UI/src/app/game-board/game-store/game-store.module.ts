import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import * as gameSessionStore from './';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    StoreModule.forFeature(gameSessionStore.category.featureKey, gameSessionStore.category.reducers),
    StoreModule.forFeature(gameSessionStore.game.featureKey, gameSessionStore.game.reducers),
    StoreModule.forFeature(gameSessionStore.questions.featureKey, gameSessionStore.questions.reducers),
    StoreModule.forFeature(gameSessionStore.rounds.featureKey, gameSessionStore.rounds.reducers),
    EffectsModule.forFeature([
      gameSessionStore.category.effects,
      gameSessionStore.game.effects,
      gameSessionStore.questions.effects,
      gameSessionStore.navigation.effects,
      gameSessionStore.rounds.effects
    ]),
  ]
})
export class GameStoreModule { }
