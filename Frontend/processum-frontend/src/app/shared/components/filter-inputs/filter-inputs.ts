import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LucideAngularModule } from 'lucide-angular';
import { Funnel, Search, Eraser } from 'lucide-angular/src/icons';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputMaskModule } from 'primeng/inputmask';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { DatePickerModule } from 'primeng/datepicker';


interface Status {
    name: string;
    code: string;
}

const MODULES = [FloatLabelModule, InputMaskModule, FormsModule, LucideAngularModule, InputTextModule, SelectModule, DatePickerModule];


@Component({
  selector: 'app-filter-inputs',
 imports: [...MODULES],
  templateUrl: './filter-inputs.html',
  styleUrl: './filter-inputs.css',
})
export class FilterInputs {
    protected readonly Funnel = Funnel;
    protected readonly Search = Search;
    protected readonly Eraser = Eraser;

    status: Status[] = [
      { name: 'Em Andamento', code: '1' },
      { name: 'Arquivado', code: '2' },
    ];

    selectedCity: Status = this.status[0];
}
