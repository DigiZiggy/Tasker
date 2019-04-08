import {IBaseEntity} from "./IBaseEntity";

export interface ICity extends IBaseEntity {
  cityValue: string;
  cityCount: number;
}
