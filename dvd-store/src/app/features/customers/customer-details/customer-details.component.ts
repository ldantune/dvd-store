import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { NotificationService } from '../../../core/services/notification.service';
import { HeaderTitleService } from '../../../core/services/header-title.service';
import { CustomerService } from '../../../core/services/customer.service';
import { Customer } from '../../../core/models/Customer';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { RentalService } from '../../../core/services/rental.service';
import { Rental } from '../../../core/models/Rental';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { InventoryService } from '../../../core/services/inventory.service';
import { RentalDetailsComponent } from "./rental-details/rental-details.component";


@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css'],
  standalone: true,
  imports: [
    RouterOutlet,
    CommonModule,
    MatCardModule,
    MatDividerModule,
    MatTableModule,
    MatButtonModule,
    MatPaginatorModule,
    RentalDetailsComponent
],
})
export class CustomerDetailsComponent implements OnInit {
  displayedColumns: string[] = [
    'rentalId',
    'rentalDate',
    'inventoryId',
    'returnDate',
    'staffId',
    'lastUpdate',
    'actions',
  ];
  customerId: number | null = null;
  selectedInventoryId : number | null = null;

  customer: Customer | null = null;
  rentalsCustomer: Rental[] = [];
  currentPage: number = 1; // Página atual (começando em 1)
  totalItems: number = 0; // Total de itens retornados pela API
  pageSize: number = 5;

  constructor(
    private route: ActivatedRoute,
    private notificationService: NotificationService,
    private headerTitleService: HeaderTitleService,
    private customerService: CustomerService,
    private rentalService: RentalService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.customerId = Number(params.get('id'));
      this.headerTitleService.setTitle('Detalhes do Cliente');
      this.getCustomerById(this.customerId);
      this.getRentalByCustomerId(this.customerId, this.currentPage, this.pageSize);
    });
  }

  private getCustomerById(customerId: number): void {
    this.customerService.getCustomerById(customerId).subscribe(
      (customer) => {
        if (customer) {
          this.customer = customer;
        } else {
          this.notificationService.showError('Customer not found');
        }
      },
      (erro: any) => {
        this.notificationService.showError('Error loading customer');
      }
    );
  }

  private getRentalByCustomerId(customerId: number, pageIndex: number, pageSize: number): void {
    this.rentalService.getRentalByCustomerId(customerId, pageIndex, pageSize).subscribe(
      (response) => {
        if (response.rentals) {
          this.rentalsCustomer = response.rentals;
          this.totalItems = response.totalItems; // Total de itens retornado pela API
          this.currentPage = pageIndex; // Atualiza a página atual
          console.log(this.rentalsCustomer);
        } else {
          this.notificationService.showError(
            'Rentals by customer Id not found'
          );
        }
      },
      (erro: any) => {
        this.notificationService.showError('Error loading rentals');
      }
    );
  }

  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize; // Atualiza o número de itens por página
    this.getRentalByCustomerId(this.customerId!, event.pageIndex + 1, this.pageSize); // Incrementa o índice da página para corresponder ao esperado pela API
  }

  navigateToRentalDetails(inventoryId: number): void {
    this.selectedInventoryId = inventoryId;
  }
}
