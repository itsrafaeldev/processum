import { Component } from '@angular/core';

@Component({
  selector: 'app-new-process-button',
  imports: [],
  templateUrl: './new-process-button.html',
  styleUrl: './new-process-button.css',
})
export class NewProcessButton {
  onNewProcess() {
    console.log('Novo processo iniciado');
  }

}
