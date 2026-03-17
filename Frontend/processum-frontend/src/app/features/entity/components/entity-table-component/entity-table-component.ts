import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { ColDef } from 'ag-grid-community';


import { Eye, Pencil, Trash2 } from 'lucide-angular/src/icons';
import { TableAgGridComponent } from '../../../../shared/components/table-ag-grid/table-ag-grid';
import { ButtonActionGrid } from '../../../process/components/button-action-grid/button-action-grid';
import { Router } from '@angular/router';
import { maskCpfCnpj } from '../../../../shared/utils/masks/masks';

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

  private router = inject(Router);

  onRowClicked(event: any) {
    const id = event.data.idPublic;

    if (event.data.entityType === 'PF') {
      this.router.navigate(['entidades/editar/pf', id]);
    }else {
      this.router.navigate(['entidades/editar/pj', id]);
    }
  }


  colDefs: ColDef[] = [
    {
      field: 'name',
      headerName: 'Nome',
      flex: 1,
      minWidth: 200
    },
    {
      field: 'tradeName',
      headerName: 'Razão Social',
      flex: 1,
      minWidth: 250
    },
    {
      headerName: 'Documento',
      flex: 1,
      valueGetter: ({ data }) => {

        if (!data) return '';

        return data.entityType === 'PF'
          ? maskCpfCnpj(data?.cpf)
          : maskCpfCnpj(data?.cnpj);
      }
    },
    {
      field: 'entityType',
      headerName: 'Pessoa',
      flex: 1,
      valueGetter: ({ data }) => {

        if (!data) return '';

        return data.entityType === 'PF'
          ? 'Física'
          : 'Jurídica';
      }
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
            class: 'text-red-600 hover:bg-red-200',
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
