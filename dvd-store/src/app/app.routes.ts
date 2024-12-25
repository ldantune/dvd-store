import { Routes } from '@angular/router';
import { CategoriesComponent } from './app/features/categories.component';

import { HomeComponent } from './home/home.component';
import { FilmsCategoryComponent } from './app/features/films-category/films-category.component';
import { AddCategoryComponent } from './app/features/categories/add-category.component';



export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' }, // Rota inicial agora direciona para o componente Home
    { path: 'home', component: HomeComponent },  // Rota para o componente Home
    { path: 'categories', component: CategoriesComponent },   // Rota principal para listar categorias
    { path: 'categories/add', component: AddCategoryComponent }, // Rota para adicionar categoria
    { path: 'films-category/:id', component: FilmsCategoryComponent},
    // {
    //     path: 'categorias',
    //     loadChildren: () =>
    //       import('./features/categorias/categoria.routes').then(
    //         (m) => m.routes
    //       ), 
    //   },
];
