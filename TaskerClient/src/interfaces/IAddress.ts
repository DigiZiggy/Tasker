import {IBaseEntity} from "./IBaseEntity";

export interface IAddress extends IBaseEntity {
  addressValue: string;
  addressCount: number;
}
