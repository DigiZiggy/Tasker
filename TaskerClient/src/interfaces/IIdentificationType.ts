import {IBaseEntity} from "./IBaseEntity";

export interface IIdentificationType extends IBaseEntity {
  identificationTypeValue: string;
  identificationTypeCount: number;
}
