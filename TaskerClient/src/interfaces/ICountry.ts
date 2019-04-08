import {IBaseEntity} from "./IBaseEntity";

export interface ICountry extends IBaseEntity {
  countryValue: string;
  countryCount: number;
}
