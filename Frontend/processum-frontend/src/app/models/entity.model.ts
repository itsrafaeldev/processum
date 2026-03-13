import { EntityCompany } from "./entity-company.model";
import { EntityIndividual } from "./entity-individual.model";

export interface Entity {
  id: number;

  entityType: string;

  statusId: number;

  createdAt: string;

  updatedAt: string;

  idPublic: string;

  entityIndividual?: EntityIndividual;

  entityCompany?: EntityCompany;

  // legalFeesInstallments: LegalFeesInstallment[];

  // judicialProcessEntities: JudicialProcessEntity[];

  // legalFeeEntities: LegalFeeEntity[];
}
