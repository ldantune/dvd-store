import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { RouterModule } from '@angular/router';
import { Actor } from '../../core/models/Actor';
import { NotificationService } from '../../core/services/notification.service';
import { HeaderTitleService } from '../../core/services/header-title.service';
import { ActorService } from '../../core/services/actor.service';
import { response } from 'express';

@Component({
  selector: 'app-actors',
  templateUrl: './actors.component.html',
  styleUrls: ['./actors.component.css'],
  standalone: true,
  imports: [RouterModule, CommonModule, MatTableModule, MatPaginatorModule],
})
export class ActorsComponent implements OnInit {
  displayedColumns: string[] = ['firstName', 'lastName', 'lastUpdate'];

  currentPage: number = 1; // Página atual (começando em 1)
  totalItems: number = 0; // Total de itens retornados pela API
  pageSize: number = 10; // Itens por página

  actors: Actor[] = [];

  constructor(
    private notificationService: NotificationService,
    private headerTitleService: HeaderTitleService,
    private actorService: ActorService
  ) { }

  ngOnInit() {
    this.headerTitleService.setTitle('Atores');
    this.getAll(this.currentPage);
  }

  private getAll(pageIndex: number = 1, pageSize: number = 10): void {
    this.actors = [];

    this.actorService.getAllActors(pageIndex, pageSize).subscribe(
      (response: any) => {
        if(response && Array.isArray(response.actors)){
          this.actors = response.actors;
          this.totalItems = response.totalItems;
          this.currentPage = pageIndex;
        }else{
          this.notificationService.showError('Erro ao carregar atores');
        }
      },
      (error) => {
        this.notificationService.showError('Erro ao carregar atores');
      }
    );
  }

  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize; // Atualiza o número de itens por página
    this.getAll(event.pageIndex + 1, this.pageSize); // Incrementa o índice da página para corresponder ao esperado pela API
  }
}
