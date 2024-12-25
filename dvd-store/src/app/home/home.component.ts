import { Component, OnInit } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { Category } from '../app/core/models/Category';
import { CategoryService } from '../app/core/services/category.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HeaderTitleService } from '../app/core/services/header-title.service';

@Component({
    selector: 'app-home',
    imports: [
        CommonModule,
        MatCardModule,
        MatButtonModule,
        MatListModule,
        MatIconModule,
    ],
    templateUrl: './home.component.html',
    styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  categories: Category[] = [];

  constructor(
    private categoryService: CategoryService,
    private router: Router,
    private headerTitleService: HeaderTitleService
  ) {}

  ngOnInit(): void {
    // Agora, o subscribe vai funcionar corretamente com o Observable
    this.getCategories();
    const categoryTitle = "Categorias"
    this.headerTitleService.setTitle('Lista de Categorias');
  }

  private getCategories(): void {
    this.categories = [];
    this.categoryService.getCategories().subscribe(
      (response: any) => {
        if (response && Array.isArray(response.categories)) {
          this.categories = response.categories;
        } else {
          console.error('O retorno não contém um array de categorias.');
        }
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  navigateToFilmsCategory(categoryId: number): void {
    this.router.navigate(['/films-category', categoryId]);
  }
}
