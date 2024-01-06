import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ModeSelectorComponent } from './mode-selector/mode-selector.component';
import { GameSelectorComponent } from './game-board/game-selector/game-selector.component';

const routes: Routes = [
  { path: '',   redirectTo: '/selector', pathMatch: 'full' },
  { path: 'selector', component: ModeSelectorComponent }
];
const routeOptions = {
  bindToComponentInputs: true
};

@NgModule({
  imports: [RouterModule.forRoot(routes, routeOptions)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
