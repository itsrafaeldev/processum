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

  cep?: string;

  houseNumber?: string;

  complement?: string;

  city: string;

  district: string;

  uf: string;

  

  cnpj: string;

  corporateName: string;

  tradeName: string;

  corporateEmail: string;

  corporateMobile?: string;

  corporatePhone?: string;

  // legalFeesInstallments: LegalFeesInstallment[];

  // judicialProcessEntities: JudicialProcessEntity[];

  // legalFeeEntities: LegalFeeEntity[];
}
