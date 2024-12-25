import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideToastr } from 'ngx-toastr';

import { routes } from './app.routes';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideClientHydration(withEventReplay()),
    provideHttpClient(withFetch()),
    provideAnimations(),
    provideToastr({
      timeOut: 5000, // 3 segundos
      progressBar: true, // Exibe a barra de progresso
      //positionClass: 'toast-bottom-right', // Posição do toast
      preventDuplicates: true, // Evita mensagens duplicadas
      tapToDismiss: true, // Permite clicar para fechar
      extendedTimeOut: 1000, // Tempo extra se o usuário interagir com o toast
    }),
  ],
};
