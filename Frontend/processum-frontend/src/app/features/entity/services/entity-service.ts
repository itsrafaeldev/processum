import { Injectable } from '@angular/core';
import { HttpBaseService } from '../../../shared/services/httpbase-service';
import { ProcessEntity } from '../../../models/process-entity.model';
import { environment } from '../../../shared/environments/environment';
import { HttpClient } from '@angular/common/http';
import { EntityIndividualRequest } from '../../../dto/entity-request';
import { Observable } from 'rxjs';
import { Entity } from '../../../models/entity.model';


@Injectable({
  providedIn: 'root',
})
export class EntityService extends HttpBaseService<Entity, string> {
    constructor(http: HttpClient) {
      super(http, `${environment.apiUrl}/entity`);
    }

    searchClients(client: string) {
      return this.http.get<any[]>(`${this.baseUrl}/clients?name=${client}`);
    }

    createEntityIndividual(entity: EntityIndividualRequest): Observable<void> {
      return this.http.post<void>(`${this.baseUrl}/pf`, entity);
    }




}
