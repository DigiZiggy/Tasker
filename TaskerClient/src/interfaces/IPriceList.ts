import {IBaseEntity} from "./IBaseEntity";

export interface IPriceList extends IBaseEntity {
  priceListValue: string;
  priceListCount: number;
}
