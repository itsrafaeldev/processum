import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { LucideAngularModule } from "lucide-angular";

const MODULES = [CommonModule];

@Component({
  selector: 'app-button-action-grid',
  imports: [...MODULES, LucideAngularModule],
  templateUrl: './button-action-grid.html',
  styleUrl: './button-action-grid.css',
})
export class ButtonActionGrid implements ICellRendererAngularComp {
  params!: any;
  actions!: any [];

  agInit(params: any): void {
    this.params = params;
    this.actions = params.actions;
  }

  refresh(): boolean {
    return false;
  }

}
