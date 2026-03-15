import { EntityCompany } from "./entity-company.model";
import { EntityIndividual } from "./entity-individual.model";

export interface  Entity {

  entityType: string;

  statusId: number;

  idPublic: string;

  name?: string;

  cpf?: string;

  rg?: string;

  email?: string;

  mobile?: string;

  phone?: string;

  birthDate?: string;

  address?: string;

  createdAt: string;

  updatedAt: string;

  // legalFeesInstallments: LegalFeesInstallment[];

  // judicialProcessEntities: JudicialProcessEntity[];

  // legalFeeEntities: LegalFeeEntity[];
}
