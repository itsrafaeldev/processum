import { Routes } from '@angular/router';
import { MainComponent } from './layouts/main/main';
import { PROCESS_ROUTES } from './features/process/routes/process.routes';
import { ENTITY_ROUTES } from './features/entity/routes/entityroutes';
import { FINANCE_ROUTES } from './features/finance/routes/finance.routes';

export const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      { path: '', redirectTo: 'processos', pathMatch: 'full' },
      ...PROCESS_ROUTES,
      ...FINANCE_ROUTES,
      ...ENTITY_ROUTES,
    ]
  }
];
