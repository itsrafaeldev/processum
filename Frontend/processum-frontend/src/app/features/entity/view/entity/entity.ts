import { Component } from '@angular/core';
import { CardRegisterEntityComponent } from '../../components/card-register-entity-component/card-register-entity-component';
import { User, Building  } from 'lucide-angular/src/icons';


@Component({
  selector: 'app-entity',
  imports: [CardRegisterEntityComponent],
  templateUrl: './entity.html',
  styleUrl: './entity.css',
})
export class EntityComponent {

  public readonly User = User;
  public readonly Building = Building;

registerEntityIndividual() {
  console.log('Cadastrar PF');
}
registerEntityCompany() {
  console.log('Cadastrar PJ');
}
}
