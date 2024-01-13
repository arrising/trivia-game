import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { NavigationBarMenuDirective } from './navigation-bar/navigation-bar-menu.directive';
import { PageComponent } from './page/page.component';
import { NavigationBarTitleDirective } from './navigation-bar/navigation-bar-title.directive';

@NgModule({
  declarations: [
    NavigationBarComponent,
    NavigationBarMenuDirective,
    NavigationBarTitleDirective,
    PageComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    NavigationBarComponent,
    NavigationBarMenuDirective,
    NavigationBarTitleDirective,
    PageComponent
  ]
})
export class LayoutModule { }
