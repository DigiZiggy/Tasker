import {IBaseEntity} from "./IBaseEntity";

export interface IPayment extends IBaseEntity {
  paymentValue: string;
  paymentCount: number;
}
