import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ModeSelectorComponent } from './mode-selector/mode-selector.component';
import { GameSelectorComponent } from './game-selector/game-selector.component';
import { GameService } from './data/game.service';
import { GameBoardModule } from './game-board/game-board.module';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';

@NgModule({
  declarations: [
    AppComponent,
    ModeSelectorComponent,
    GameSelectorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    GameBoardModule,
    StoreModule.forRoot({}),
    EffectsModule.forRoot([])
  ],
  providers: [
    GameService
  ],
  bootstrap: [AppComponent],
  exports: [
  ]
})
export class AppModule { }
