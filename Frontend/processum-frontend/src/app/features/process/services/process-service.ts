import { Injectable } from '@angular/core';
import { Process } from '../../../models/process.model';
import { HttpBaseService } from '../../../shared/services/httpbase-service';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../shared/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ProcessService extends HttpBaseService<Process, string> {

  constructor(http: HttpClient) {
    super(http, `${environment.apiUrl}/process`);
  }
}
