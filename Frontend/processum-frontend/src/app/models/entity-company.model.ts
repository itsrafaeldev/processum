export interface EntityCompany {
  id: number;
  entityId: number;

  cnpj?: string;
  corporateName?: string;
  tradeName?: string;

  corporateEmail?: string;
  corporateMobile?: string;
  corporatePhone?: string;

  createdAt: string;
  updatedAt: string;
}
