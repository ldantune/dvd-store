import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { InventoryService } from '../../../../core/services/inventory.service';

@Component({
  selector: 'app-rental-details',
  templateUrl: './rental-details.component.html',
  styleUrls: ['./rental-details.component.css'],
  standalone: true,
  imports: [CommonModule],
})
export class RentalDetailsComponent implements OnInit {
  @Input() inventoryId!: number;

  constructor(
    private route: ActivatedRoute,
    private inventoryService: InventoryService,
    private router: Router) {}

  ngOnInit() {
  }
}
