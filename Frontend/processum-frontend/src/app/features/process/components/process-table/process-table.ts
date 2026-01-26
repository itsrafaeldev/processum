import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';
import { ColDef } from 'ag-grid-community';
import { AsyncPipe } from '@angular/common';
import { LucideAngularModule } from 'lucide-angular';
import { ButtonModule } from 'primeng/button';

import { ButtonActionGrid } from '../button-action-grid/button-action-grid';
import { AG_GRID_LOCALE_PT_BR } from '../../../../shared/ag-grid/ag-grid-locale-pt';
import { maskProcessDataPtBr, maskProcessNumber } from '../../../../shared/utils/masks/masks';
import { Eye, Pencil, Trash2 } from 'lucide-angular/src/icons';

@Component({
  selector: 'app-process-table',
  standalone: true,
  imports: [
    AgGridAngular,
    LucideAngularModule,
    ButtonModule,
    AsyncPipe
  ],
  templateUrl: './process-table.html',
  styleUrl: './process-table.css',
})
export class ProcessTableComponent {

  // 🔹 Dados vêm de fora
  @Input({ required: true }) rowData$!: any;

  // 🔹 Eventos sobem para o componente pai
  @Output() view = new EventEmitter<any>();
  @Output() edit = new EventEmitter<any>();
  @Output() delete = new EventEmitter<any>();

  localeText = AG_GRID_LOCALE_PT_BR;

  colDefs: ColDef[] = [
    {
      field: 'processNumber',
      headerName: 'Nº Processo',
      flex: 1,
      minWidth: 200,
      valueFormatter: p => maskProcessNumber(p.value)
    },
    {
      headerName: 'Cliente',
      flex: 1,
      minWidth: 250,
      valueGetter: p =>
        p.data?.entities?.[0]?.name ??
        p.data?.entities?.[0]?.corporateName ??
        ''
    },
    {
      headerName: 'Natureza',
      valueGetter: p => p.data?.natureAction?.text ?? ''
    },
    {
      field: 'isArchived',
      headerName: 'Status',
      valueGetter: p => p.data?.isArchived ? 'Arquivado' : 'Em Andamento'
    },
    {
      field: 'initialDate',
      headerName: 'Data Inicial',
      valueFormatter: p => maskProcessDataPtBr(p.value)
    },
    {
      headerName: 'Ações',
      cellRenderer: ButtonActionGrid,
      headerClass: 'ag-center-header',
      filter: false,
      cellRendererParams: {
        useDropdown: true,
        actions: [
          {
            icon: Eye,
            label: 'Visualizar',
            class: 'text-primary-400 hover:bg-primary-100',
            onClick: (row: any) => this.view.emit(row)
          },
          {
            icon: Pencil,
            label: 'Editar',
            class: 'text-primary-400 hover:bg-primary-100',
            onClick: (row: any) => this.edit.emit(row)
          },
          {
            icon: Trash2,
            label: 'Excluir',
            class: 'text-red-600 hover:bg-red-300',
            onClick: (row: any) => this.delete.emit(row)
          }
        ]
      }
    }
  ];

  defaultColDef: ColDef = {
    filter: true,
    sortable: true,
    resizable: true,
  };

  gridOptions = {
    popupParent: document.body,
    suppressRowTransform: true
  };
}
