import { Component, inject } from '@angular/core';
import { Observable, of } from 'rxjs';

import { CardRegisterEntityComponent } from '../../components/card-register-entity-component/card-register-entity-component';
import { EntityTableComponent } from '../../components/entity-table-component/entity-table-component';

import { User, Building } from 'lucide-angular/src/icons';
import { EntityService } from '../../services/entity-service';
import { FilterEntityComponent } from "../../components/filter-entity-component/filter-entity-component";

@Component({
  selector: 'app-entity',
  standalone: true,
  imports: [
    EntityTableComponent,
    FilterEntityComponent,
],
  templateUrl: './entity.html',
  styleUrl: './entity.css',
})
export class EntityComponent {

  public readonly User = User;
  public readonly Building = Building;
  private entityService = inject(EntityService);

  entities$ = this.entityService.getAll();

  registerEntityIndividual() {
    console.log('Cadastrar PF');
  }

  registerEntityCompany() {
    console.log('Cadastrar PJ');
  }

  openView(row: any) {
    console.log('Visualizar', row);
  }

  openEdit(row: any) {
    console.log('Editar', row);
  }

  deleteEntity(row: any) {
    console.log('Excluir', row);
  }

}
