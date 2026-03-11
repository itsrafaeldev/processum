import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ColDef } from 'ag-grid-community';


import { Eye, Pencil, Trash2 } from 'lucide-angular/src/icons';
import { TableAgGridComponent } from '../../../../shared/components/table-ag-grid/table-ag-grid';
import { ButtonActionGrid } from '../../../process/components/button-action-grid/button-action-grid';

@Component({
  selector: 'app-entity-table',
  standalone: true,
  imports: [
    TableAgGridComponent
  ],
  templateUrl: './entity-table-component.html',
  styleUrl: './entity-table-component.css',
})
export class EntityTableComponent {

  @Input({ required: true }) rowData$!: any;

  @Output() view = new EventEmitter<any>();
  @Output() edit = new EventEmitter<any>();
  @Output() delete = new EventEmitter<any>();

  colDefs: ColDef[] = [
    {
      field: 'name',
      headerName: 'Nome',
      flex: 1,
      minWidth: 200
    },
    {
      field: 'corporateName',
      headerName: 'Razão Social',
      flex: 1,
      minWidth: 250
    },
    {
      field: 'document',
      headerName: 'Documento',
      flex: 1
    },
    {
      field: 'email',
      headerName: 'Email',
      flex: 1
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
