import { Component, OnInit } from '@angular/core';
import { Customer } from '../../core/models/Customer';
import { NotificationService } from '../../core/services/notification.service';
import { HeaderTitleService } from '../../core/services/header-title.service';
import { CustomerService } from '../../core/services/customer.service';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
  standalone: true,
  imports: [RouterModule, CommonModule, MatTableModule, MatPaginatorModule, MatButtonModule],
})
export class CustomersComponent implements OnInit {
  displayedColumns: string[] = [
    'firstName',
    'lastName',
    'email',
    'activebool',
    'createDate',
    'lastUpdate',
    'actions',
  ];

  currentPage: number = 1; // Página atual (começando em 1)
  totalItems: number = 0; // Total de itens retornados pela API
  pageSize: number = 10;

  customers: Customer[] = [];

  constructor(
    private notificationService: NotificationService,
    private headerTitleService: HeaderTitleService,
    private customerService: CustomerService,
    private router: Router
  ) {}

  ngOnInit() {
    this.headerTitleService.setTitle('Clientes');
    this.getAll(this.currentPage);
  }

  private getAll(pageIndex: number = 1, pageSize: number = 10): void {
    this.customers = [];

    this.customerService.getAllCustomers(pageIndex, pageSize).subscribe(
      (response: any) => {
        if (response && Array.isArray(response.customers)) {
          this.customers = response.customers;
          this.totalItems = response.totalItems; // Total de itens retornado pela API
          this.currentPage = pageIndex; // Atualiza a página atual
        } else {
          this.notificationService.showError('Erro ao carregar as clientes');
        }
      },
      (error: any) => {
        this.notificationService.showError('Erro ao carregar as clientes');
      }
    );
  }

  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize; // Atualiza o número de itens por página
    this.getAll(event.pageIndex + 1, this.pageSize); // Incrementa o índice da página para corresponder ao esperado pela API
  }

  navigateToDetailsCustomer(customerId: number): void {
    this.router.navigate(['clientes/detalhes', customerId]);
  }

  
}
