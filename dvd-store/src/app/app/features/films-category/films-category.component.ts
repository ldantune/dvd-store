import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieCategory } from '../../core/models/MovieCategory';
import { FilmCategoryService } from '../../core/services/film-category.service';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { HeaderTitleService } from '../../core/services/header-title.service';

@Component({
  selector: 'app-films-category',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatButtonModule],
  templateUrl: './films-category.component.html',
  styleUrls: ['./films-category.component.css'],
})
export class FilmsCategoryComponent implements OnInit {
  categoryId: number | null = null;
  categoryTitle: string = '';
  moviesCategory: MovieCategory[] = [];

  constructor(
    private headerTitleService: HeaderTitleService,
    private route: ActivatedRoute,
    private filmCategoryService: FilmCategoryService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.categoryId = Number(params.get('id'));
      //this.headerTitleService.setTitle(this.categoryTitle);
      this.getFilmsByCategoriId(this.categoryId);
    });
  }

  private getFilmsByCategoriId(category_id: number): void {
    this.moviesCategory = [];
    this.filmCategoryService.getFilmsByCategoryId(category_id).subscribe(
      (response: any) => {
        if (response && Array.isArray(response.moviesByCategory)) {
          this.moviesCategory = response.moviesByCategory;
          let nameCategory = this.moviesCategory[0].nameCategory;
          this.headerTitleService.setTitle(nameCategory);
        } else {
          console.error('O retorno não contém um array de categorias.');
        }
      },
      (error: any) => {
        console.error(error);
      }
    );
  }
}
