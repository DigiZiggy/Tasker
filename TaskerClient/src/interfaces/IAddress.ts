import {IBaseEntity} from "./IBaseEntity";

export interface IAddress extends IBaseEntity {
  Country: string;
  City: string;
  Street: string;
  HouseNumber: string;
  UnitNumber: string;
  PostalCode: string;
}
