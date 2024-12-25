import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-content',
  standalone: true,
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css'],
  imports: [RouterOutlet]
})
export class ContentComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
