import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { MatGridListModule } from '@angular/material/grid-list';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [
    RouterModule,
    MatButtonModule,
    MatDividerModule,
    MatIconModule,
    MatGridListModule,
  ],
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
