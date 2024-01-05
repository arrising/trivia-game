import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { NavigationBarMenuDirective } from './navigation-bar/navigation-bar-menu.directive';



@NgModule({
  declarations: [
    NavigationBarComponent,
    NavigationBarMenuDirective
  ],
  imports: [
    CommonModule
  ],
  exports: [
    NavigationBarComponent,
    NavigationBarMenuDirective
  ]
})
export class LayoutModule { }
