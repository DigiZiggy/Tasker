import {IBaseEntity} from "./IBaseEntity";

export interface IInvoice extends IBaseEntity {
  invoiceValue: string;
  invoiceCount: number;
}
