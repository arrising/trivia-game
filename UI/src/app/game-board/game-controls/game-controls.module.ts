import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExitButtonComponent } from './exit-button/exit-button.component';
import { GameSelectButtonComponent } from './game-select-button/game-select-button.component';



@NgModule({
  declarations: [
    ExitButtonComponent,
    GameSelectButtonComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ExitButtonComponent,
    GameSelectButtonComponent
  ]
})
export class GameControlsModule { }
