import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private toastr: ToastrService) {}

  showSuccess(message: string) {
    const toastRef = this.toastr.success(message, 'Sucesso!');
    setTimeout(() => {
      this.toastr.clear(toastRef.toastId); // Força o fechamento
    }, 5000);
  }

  showError(message: string) {
    const toastRef = this.toastr.error(message, 'Erro!');
    setTimeout(() => {
      this.toastr.clear(toastRef.toastId); // Força o fechamento
    }, 5000);
  }

  showAlert(message: string) {
    const toastRef = this.toastr.warning(message, 'Atenção!');
    setTimeout(() => {
      this.toastr.clear(toastRef.toastId); // Força o fechamento
    }, 5000);
  }

}
