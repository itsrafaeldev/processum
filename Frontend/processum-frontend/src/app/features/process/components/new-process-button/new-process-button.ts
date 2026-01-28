import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-process-button',
  imports: [],
  templateUrl: './new-process-button.html',
  styleUrl: './new-process-button.css',
})
export class NewProcessButton {

  private router = inject(Router);

  onNewProcess() {
    console.log('Novo processo iniciado');
    this.router.navigate(['/processos/novo']);
  }

}
