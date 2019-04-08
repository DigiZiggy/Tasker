import {IBaseEntity} from "./IBaseEntity";

export interface IPrice extends IBaseEntity {
  priceValue: string;
  priceCount: number;
}
