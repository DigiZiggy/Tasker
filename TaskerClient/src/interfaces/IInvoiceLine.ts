import {IBaseEntity} from "./IBaseEntity";

export interface IInvoiceLine extends IBaseEntity {
  invoiceLineValue: string;
  invoiceLineCount: number;
}
