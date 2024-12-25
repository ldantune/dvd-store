import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { Category } from './models/Category';

import { NotificationService } from '../../core/services/notification.service';
import { HeaderTitleService } from '../../core/services/header-title.service';
import { CategoriaService } from './services/categoria.service';

import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';

@Component({
    selector: 'app-categoria',
    templateUrl: './categoria.component.html',
    styleUrls: ['./categoria.component.css'],
    standalone: true,
    imports:[RouterModule, CommonModule, MatTableModule, MatPaginatorModule]
})
export class CategoriaComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'nome',
    'dataAtualizacao',
  ];
  categorias: Category[] = [];
  data = new MatTableDataSource<any>([]);

  constructor(
    private notificationService: NotificationService,
    private headerTitleService: HeaderTitleService,
    private categoriaService: CategoriaService,
    private dialog: MatDialog
  ) { }

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.data.paginator = this.paginator;
  }

  ngOnInit() {
    this.headerTitleService.setTitle('Categorias');
    this.getAll();
  }

  private getAll(): void {
    this.categorias = [];
    this.categoriaService.getAll().subscribe(
      (response: any) => {
        if (response && Array.isArray(response.categories)) {
          console.log(response.categories);
          this.data = new MatTableDataSource<Category>(response.categories);
          this.notificationService.showSuccess('Categorias carregadas com sucesso!');
        } else {
          this.notificationService.showError('Erro ao carregar as categorias');
        }
      },
      (error: any) => {
        this.notificationService.showError('Erro ao carregar as categorias');
      }
    );
  }

}
