import {IBaseEntity} from "./IBaseEntity";
import DateTimeFormat = Intl.DateTimeFormat;

export interface IInvoice extends IBaseEntity {
  InvoiceNumber: number;
  Date: DateTimeFormat;
  TotalWithVAT: number;
  TotalWithoutVAT: number;
  VAT: number;
  Comment: string;
}
