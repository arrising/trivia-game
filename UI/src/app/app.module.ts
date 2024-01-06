import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { GameService } from './data/game.service';
import { GameBoardModule } from './game-board/game-board.module';
import { EffectsModule } from '@ngrx/effects';
import { LayoutModule } from './layout/layout.module';
import { AppComponent } from './app.component';
import { ModeSelectorComponent } from './mode-selector/mode-selector.component';

@NgModule({
  declarations: [
    AppComponent,
    ModeSelectorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    GameBoardModule,
    LayoutModule,
    StoreModule.forRoot({}),
    EffectsModule.forRoot([]),
    StoreDevtoolsModule.instrument({
      maxAge: 25
    })
  ],
  providers: [
    GameService
  ],
  bootstrap: [AppComponent],
  exports: [
  ]
})
export class AppModule { }
