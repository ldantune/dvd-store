import { Component } from '@angular/core';
import { FooterComponent } from './app/shared/template/footer/footer.component';
import { HeaderComponent } from './app/shared/template/header/header.component';
import { MenuComponent } from './app/shared/template/menu/menu.component';
import { ContentComponent } from './app/shared/template/content/content.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FooterComponent, HeaderComponent, MenuComponent, ContentComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'dvd-store';
}
