import { createGrid, ModuleRegistry, AllCommunityModule } from 'ag-grid-community';
import { AG_GRID_LOCALE_BR } from '@ag-grid-community/locale';

ModuleRegistry.registerModules([AllCommunityModule]);

window.AG_GRID_LOCALE_BR = AG_GRID_LOCALE_BR
window.createGrid = createGrid;
