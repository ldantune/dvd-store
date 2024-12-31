import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { InventoryService } from '../../../../core/services/inventory.service';
import { Inventory } from '../../../../core/models/Inventory';
import { NotificationService } from '../../../../core/services/notification.service';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';

@Component({
  selector: 'app-rental-details',
  templateUrl: './rental-details.component.html',
  styleUrls: ['./rental-details.component.css'],
  standalone: true,
  imports: [CommonModule, MatCardModule, MatChipsModule],
})
export class RentalDetailsComponent implements OnInit {
  private _inventoryId!: number;
  parsedArray: { word: string; count: number }[] = [];
  inventory: Inventory | null = null;

  constructor(
    private route: ActivatedRoute,
    private inventoryService: InventoryService,
    private notificationService: NotificationService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  @Input()
  set inventoryId(value: number) {
    this._inventoryId = value;
    if (value) {
      this.getInventory(value);
    }
  }

  get inventoryId(): number {
    return this._inventoryId;
  }

  getInventory(inventoryId: number) {
    this.inventoryService.getByInventoryId(inventoryId).subscribe(
      (response: any) => {
        if (response) {
          this.inventory = response;
          console.log(this.inventory!.film.fullText);
          this.parsedArray = this.parseFullText(this.inventory!.film.fullText);
          console.log(this.inventory);
        } else {
          this.notificationService.showAlert('Inventário não encontrado');
        }
      },
      (error) => {
        this.notificationService.showError('Erro ao buscar inventário');
      }
    );
  }

  parseFullText(text: string): { word: string; count: number }[] {
    return text
      .split(' ')
      .map((item) => {
        const [word, count] = item.replace(/'/g, '').split(':');
        return { word, count: Number(count) };
      });
  }
}
