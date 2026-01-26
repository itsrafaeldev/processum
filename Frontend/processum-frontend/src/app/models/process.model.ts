import { ProcessEntity } from "./process-entity.model";

export interface Process {
  idPublic: string;
  userId: number;
  amount: number;
  quantityInstallment: number;
  judicialProcessId: number;
  statusPaymentId: number;
  note: string;
  entities: ProcessEntity[];
  createdAt: string;   // ISO Date (pode converter depois)
  updatedAt: string;   // ISO Date
}
