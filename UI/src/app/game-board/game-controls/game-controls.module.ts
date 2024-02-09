import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExitButtonComponent } from './exit-button/exit-button.component';
import { GameSelectButtonComponent } from './game-select-button/game-select-button.component';
import { RoundSelectButtonComponent } from './round-select-button/round-select-button.component';

@NgModule({
  declarations: [
    ExitButtonComponent,
    GameSelectButtonComponent,
    RoundSelectButtonComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ExitButtonComponent,
    GameSelectButtonComponent,
    RoundSelectButtonComponent
  ]
})
export class GameControlsModule { }
