import { Component } from '@angular/core';
import { FooterComponent } from './shared/template/footer/footer.component';
import { HeaderComponent } from './shared/template/header/header.component';
import { MenuComponent } from './shared/template/menu/menu.component';
import { ContentComponent } from './shared/template/content/content.component';



@Component({
    selector: 'app-root',
    imports: [FooterComponent, HeaderComponent, MenuComponent, ContentComponent],
    templateUrl: './app.component.html',
    styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'dvd-store';
}
