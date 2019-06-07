import {IBaseEntity} from "./IBaseEntity";
import DateTimeFormat = Intl.DateTimeFormat;

export interface IPayment extends IBaseEntity {
  MeansOfPayment: string;
  PaymentCode: number;
  TimeOfPayment: DateTimeFormat;
  Total: number;
  Comment: string;
}
