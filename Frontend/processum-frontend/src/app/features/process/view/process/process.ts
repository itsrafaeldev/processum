import { Component, inject } from '@angular/core';
import { ProcessService } from '../../services/process-service';
import { ProcessModalService } from '../../components/modals/details-process/services/process-modal-service';
import { DetailsProcess } from '../../components/modals/details-process/details-process';
import { ProcessTableComponent } from '../../components/process-table/process-table';
import { FilterInputs } from "../../../../shared/components/filter-inputs/filter-inputs";
import { NewProcessButton } from '../../components/new-process-button/new-process-button';


@Component({
  selector: 'app-process',
  standalone: true,
  imports: [DetailsProcess, ProcessTableComponent, FilterInputs, NewProcessButton],
  templateUrl: './process.html',
  styleUrl: './process.css',
})
export class ProcessComponent {

  private processService = inject(ProcessService);
  private detailsProcess = inject(ProcessModalService);

  processes$ = this.processService.getAll();

  onView(row: any) {
    this.detailsProcess.open(row);
  }

  onEdit(row: any) {
  }

  onDelete(row: any) {
  }
}
