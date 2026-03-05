import { ChangeDetectorRef, Component, inject } from '@angular/core';
import { CommonModule, Location } from '@angular/common';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputMaskModule } from 'primeng/inputmask';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { MultiSelectModule } from 'primeng/multiselect';
import { DatePickerModule } from 'primeng/datepicker';
import { MessageModule } from 'primeng/message';
import { TextareaModule } from 'primeng/textarea';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProcessService } from '../../services/process-service';
import { EntityService } from '../../../entity/services/entity-service';
import { Save, CircleArrowLeft } from 'lucide-angular/src/icons';
import { LucideAngularModule } from 'lucide-angular';
import { ProcessRequest } from '../../../../dto/process-request.model';
import { unMask } from '../../../../shared/utils/masks/masks';




const MODULES = [FloatLabelModule,
  InputMaskModule, TextareaModule,
  InputTextModule, SelectModule, DatePickerModule,
  CommonModule, ReactiveFormsModule, MessageModule,
  LucideAngularModule, MultiSelectModule
];


@Component({
  selector: 'app-new-process',
  imports: [...MODULES],
  templateUrl: './new-process.html',
  styleUrl: './new-process.css',
})
export class NewProcess {

    private location = inject(Location);
    private formBuilder = inject(FormBuilder);
    private processService = inject(ProcessService);
    private entityService = inject(EntityService);
    private changeDetector = inject(ChangeDetectorRef);
    private searchTimeout: any;
    protected readonly Save = Save;
    protected readonly CircleArrowLeft = CircleArrowLeft;

    natures: any[] | undefined;
    actions: any[] | undefined;
    allClients: any[] = [];
    client: any[] = [];
    // client: any[] | undefined;
    loadingClients = false;
    value: string | undefined;
    processForm: FormGroup;
    formSubmitted: boolean = false;


    constructor() {
      this.processForm = this.formBuilder.group({
                  numeroProcesso: ['', Validators.required],
                  dataAbertura: ['', Validators.required],
                  reclamante: [[], Validators.required],
                  reclamado: ['', Validators.required],
                  naturezaAcao: ['', Validators.required],
                  acaoJudicial: ['', Validators.required],
                  observacoes: [''] // opcional
              });
    }

    onSubmit() {
          this.formSubmitted = true;
          if (this.processForm.valid) {
            const formValues = this.processForm.value;

            const process: ProcessRequest = {
              processNumber: unMask(formValues.numeroProcesso),
              initialDate: new Date(formValues.dataAbertura).toISOString().split('T')[0],
              respondent: formValues.reclamado,
              description: formValues.observacoes,

              natureActionId: formValues.naturezaAcao,
              judicialActionId: formValues.acaoJudicial,

              // userId: 1,
              EntityIds: formValues.reclamante
            };

            console.log(process);
            debugger
            this.processService.createProcess(process).subscribe({
              next: () =>{

              },
              error: (err) => {
                console.error('Erro ao criar processo', err);
              },
            })


              this.processForm.reset();
              this.formSubmitted = false;
              this.actions = [];
          }
      }
    goBack() {
      this.location.back();
    }

    isInvalid(controlName: string) {
          const control = this.processForm.get(controlName);
          return control?.invalid && (control.touched || this.formSubmitted);
    }

    ngOnInit(): void {
      this.loadNatures();
      const natureAction = this.processForm.get('naturezaAcao');

      if (natureAction) {
        natureAction.valueChanges.subscribe(natureId => {
          this.loadActions(natureId);
        });
      }


    }

    loadNatures() {
      this.processService.getNatures().subscribe(data => {
        this.natures = data;
      });
    }

    loadActions(natureId: number) {
      this.processService.getActions(natureId).subscribe(data => {
        this.actions = data;
      });
    }

    searchClients(event: any) {
      const query = event.filter;

      if (!query || query.length < 2) {
        if (this.searchTimeout) {
          clearTimeout(this.searchTimeout);
        }
        return;
      }

      if (this.searchTimeout) {
        clearTimeout(this.searchTimeout);
      }

      this.searchTimeout = setTimeout(() => {

        this.loadingClients = true;

        this.entityService.searchClients(query)
          .subscribe({
            next: (data) => {

              const selectedIds = this.processForm.get('reclamante')?.value || [];

              // guarda tudo que já veio
              this.allClients = [
                ...this.allClients,
                ...data.filter(d => !this.allClients.some(a => a.id === d.id))
              ];

              // pega os selecionados completos
              const selectedItems = this.allClients.filter(c =>
                selectedIds.includes(c.id)
              );

              this.client = [
                ...selectedItems.map(i => ({ ...i })),
                ...data
                  .filter(d => !selectedIds.includes(d.id))
                  .map(i => ({ ...i }))
              ];

              this.loadingClients = false;
              this.changeDetector.detectChanges();
            },
            error: () => {
              this.loadingClients = false;
            }
          });

      }, 1000);
    }












}
