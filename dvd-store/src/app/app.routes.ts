import { Routes } from '@angular/router';
import { FilmsCategoryComponent } from './features/films-category/films-category.component';
import { HomeComponent } from './features/home/home.component';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' }, // Rota inicial agora direciona para o componente Home
  { path: 'home', component: HomeComponent }, // Rota para o componente Home
  { path: 'films-category/:id', component: FilmsCategoryComponent },
  {
    path: 'categorias',
    loadChildren: () =>
      import('./features/categorias/categoria.routes').then((m) => m.routes),
  },
];
