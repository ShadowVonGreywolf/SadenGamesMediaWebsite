import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent],
  template: `
    <app-header></app-header>
    <router-outlet />
  `,
  styles: [
    `
      h1 {
        padding: 5px;
        
      }
    `
  ],
})
export class AppComponent {
  title = 'SadenGamesMedia';
}
