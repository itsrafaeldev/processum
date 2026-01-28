import { Component, inject } from '@angular/core';
import { CommonModule, Location } from '@angular/common';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputMaskModule } from 'primeng/inputmask';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { DatePickerModule } from 'primeng/datepicker';
import { MessageModule } from 'primeng/message';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';


@Component({
  selector: 'app-new-process',
  imports: [FloatLabelModule, InputMaskModule, InputTextModule, SelectModule, DatePickerModule, CommonModule, ReactiveFormsModule, MessageModule],
  templateUrl: './new-process.html',
  styleUrl: './new-process.css',
})
export class NewProcess {

  private location = inject(Location);
  // messageService = inject(MessageService);
  private formBuilder = inject(FormBuilder);
    items: any[] | undefined;
    exampleForm: FormGroup;
    formSubmitted: boolean = false;


  constructor() {
    this.exampleForm = this.formBuilder.group({
                value: ['', Validators.required]
            });
  }

  onSubmit() {
        this.formSubmitted = true;
        if (this.exampleForm.valid) {
            // this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Form is submitted', life: 3000 });
            this.exampleForm.reset();
            this.formSubmitted = false;
        }
    }
  goBack() {
    this.location.back();
  }
  isInvalid(controlName: string) {
        const control = this.exampleForm.get(controlName);
        return control?.invalid && (control.touched || this.formSubmitted);
    }
}
