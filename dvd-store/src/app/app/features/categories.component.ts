import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../core/services/category.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Category } from '../core/models/Category';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-categories',
  standalone: true,
  imports: [CommonModule, MatTableModule ],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.css',
})
export class CategoriesComponent implements OnInit {
  categories: Category[] = [];

  constructor(private categoryService: CategoryService, private router: Router) {}

  ngOnInit(): void {
    // Agora, o subscribe vai funcionar corretamente com o Observable
    this.getCategories();
  }

  navigateToAddCategory() {
    this.router.navigate(['/categories/add']);
  }

  private getCategories(): void {
    this.categories = [];
    this.categoryService.getCategories().subscribe(
      (response: any) => {

        if (response && Array.isArray(response.categories)) {
        this.categories = response.categories;
      } else {
        console.error("O retorno não contém um array de categorias.");
      }
      },
      (error: any) => {
        console.error(error);
      }
    );
  }
}
