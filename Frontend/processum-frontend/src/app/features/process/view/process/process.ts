import { Component } from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';
import {  ColDef } from 'ag-grid-community';
import 'ag-grid-community/styles/ag-theme-quartz.css';
import { ButtonActionGrid } from '../../components/button-action-grid/button-action-grid';
import { LucideAngularModule } from 'lucide-angular';
import { Eye, Pencil, Trash2 } from 'lucide-angular/src/icons';
import { AG_GRID_LOCALE_PT_BR } from '../../../../../shared/ag-grid/ag-grid-locale-pt';

const MODULES = [AgGridAngular, LucideAngularModule];
const COMPONENTS = [ButtonActionGrid];

@Component({
  selector: 'app-process',
  imports: [...MODULES],
  templateUrl: './process.html',
  styleUrl: './process.css',
})
export class ProcessComponent {
  localeText = AG_GRID_LOCALE_PT_BR;
  rowData = [
        { 'numeroProcesso': "Tesla"},
        { 'numeroProcesso': "Ford"},
        { 'numeroProcesso': "Toyota"},
    ];

  colDefs: ColDef[] = [
      {
        field: 'numeroProcesso',
        headerName: 'Nº Processo',
        flex: 1,
        minWidth: 200 },
      {
        headerName: 'Ações',
        cellRenderer: ButtonActionGrid,
        headerClass: 'ag-center-header',
        cellRendererParams: {
          actions: [
            {
              icon: Eye,
              tooltip: 'Visualizar',
              id: 'view-icon',
              class: 'text-primary-600 hover:bg-primary-100',
              onClick: (row: any) => console.log('Visualizar:', row)
            },
            {
              icon: Pencil,
              tooltip: 'Editar',
              id: 'edit-icon',
              class: 'text-primary-600 hover:bg-primary-100',
              onClick: (row: any) => console.log('Editar:', row)
            },
            {
              icon: Trash2,
              tooltip: 'Excluir',
              id: 'delete-icon',
              class: 'text-red-600 hover:bg-red-300',
              onClick: (row: any) => console.log('Excluir:', row)
            }
          ]
        }
      },
  ];

  defaultColDef: ColDef = {
    filter: true,
    sortable: true,
    resizable: true,
  };
}
