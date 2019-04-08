import {IBaseEntity} from "./IBaseEntity";

export interface IMeansOfPayment extends IBaseEntity {
  meansOfPaymentValue: string;
  meansOfPaymentCount: number;
}
