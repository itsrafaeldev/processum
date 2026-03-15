import { Component, ChangeDetectorRef, forwardRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { MultiSelectModule } from 'primeng/multiselect';
import { EntityService } from '../../../features/entity/services/entity-service';


@Component({
  selector: 'app-select-entity-component',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MultiSelectModule
  ],
  templateUrl: './select-entity-component.html',
  styleUrl: './select-entity-component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => SelectEntityComponent),
      multi: true
    }
  ]
})
export class SelectEntityComponent implements ControlValueAccessor {

  clients: any[] = [];
  allClients: any[] = [];

  loadingClients = false;

  private searchTimeout: any;

  value: any[] = [];

  onChange = (value: any) => {};
  onTouched = () => {};

  constructor(
    private entityService: EntityService,
    private cd: ChangeDetectorRef
  ) {}

  writeValue(value: any): void {
    this.value = value || [];
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  searchClients(event: any) {

    const query = event.filter;

    if (!query || query.length < 2) {
      if (this.searchTimeout) clearTimeout(this.searchTimeout);
      return;
    }

    if (this.searchTimeout) clearTimeout(this.searchTimeout);

    this.searchTimeout = setTimeout(() => {

      this.loadingClients = true;

      this.entityService.searchClients(query)
        .subscribe({
          next: (data) => {

            const selectedIds = this.value || [];

            this.allClients = [
              ...this.allClients,
              ...data.filter(d => !this.allClients.some(a => a.id === d.id))
            ];

            const selectedItems = this.allClients.filter(c =>
              selectedIds.includes(c.id)
            );

            this.clients = [
              ...selectedItems.map(i => ({ ...i })),
              ...data
                .filter(d => !selectedIds.includes(d.id))
                .map(i => ({ ...i }))
            ];

            this.loadingClients = false;
            this.cd.detectChanges();
          },
          error: () => {
            this.loadingClients = false;
          }
        });

    }, 500);
  }

  onSelectChange(event: any) {
    this.value = event.value;
    this.onChange(this.value);
  }
}
