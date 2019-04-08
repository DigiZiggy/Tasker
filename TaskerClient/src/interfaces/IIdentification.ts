import {IBaseEntity} from "./IBaseEntity";

export interface IIdentification extends IBaseEntity {
  identificationValue: string;
  identificationCount: number;
}
