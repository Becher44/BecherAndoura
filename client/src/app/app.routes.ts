import { Routes } from '@angular/router';
import { PortfolioPageComponent } from './pages/portfolio/portfolio-page.component';

export const routes: Routes = [
  {
    path: '',
    component: PortfolioPageComponent
  },
  {
    path: '**',
    redirectTo: ''
  }
];
