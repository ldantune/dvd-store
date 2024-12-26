import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { Category } from './models/Category';

import { NotificationService } from '../../core/services/notification.service';
import { HeaderTitleService } from '../../core/services/header-title.service';
import { CategoriaService } from './services/categoria.service';

import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import {
  MatPaginator,
  MatPaginatorModule,
  PageEvent,
} from '@angular/material/paginator';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.css'],
  standalone: true,
  imports: [RouterModule, CommonModule, MatTableModule, MatPaginatorModule],
})
export class CategoriaComponent implements OnInit {
  displayedColumns: string[] = ['nome', 'dataAtualizacao'];

  currentPage: number = 1; // Página atual (começando em 1)
  totalItems: number = 0; // Total de itens retornados pela API
  pageSize: number = 10;

  categorias: Category[] = [];

  constructor(
    private notificationService: NotificationService,
    private headerTitleService: HeaderTitleService,
    private categoriaService: CategoriaService
  ) {}

  ngOnInit() {
    this.headerTitleService.setTitle('Categorias');
    this.getAll(this.currentPage);
  }
  
  private getAll(pageIndex: number = 1, pageSize: number = 10): void {
    this.categorias = [];
    
    this.categoriaService.getAll(pageIndex, pageSize).subscribe(
      (response: any) => {
        if (response && Array.isArray(response.categories)) {
          this.categorias = response.categories;
          this.totalItems = response.totalItems; // Total de itens retornado pela API
          this.currentPage = pageIndex;         // Atualiza a página atual
        } else {
          this.notificationService.showError('Erro ao carregar as categorias');
        }
      },
      (error: any) => {
        this.notificationService.showError('Erro ao carregar as categorias');
      }
    );
  }
  
  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize; // Atualiza o número de itens por página
    this.getAll(event.pageIndex + 1, this.pageSize); // Incrementa o índice da página para corresponder ao esperado pela API
  }
}
