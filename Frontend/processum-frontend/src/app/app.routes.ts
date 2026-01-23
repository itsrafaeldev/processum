import { Routes } from '@angular/router';
import { MainComponent } from './layouts/main/main';
import { ProcessComponent } from './features/process/view/process/process';
import { FinanceComponent } from './features/finance/view/entity/finance';
import { EntityComponent } from './features/entity/view/entity/entity';

export const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      { path: '', redirectTo: 'processos', pathMatch: 'full' },
      { path: 'processos', component: ProcessComponent },
      { path: 'financeiro', component: FinanceComponent },
      { path: 'entidades', component: EntityComponent },
    ]
  }
];
