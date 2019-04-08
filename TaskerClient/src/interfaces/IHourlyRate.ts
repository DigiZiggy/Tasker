import {IBaseEntity} from "./IBaseEntity";

export interface IHourlyRate extends IBaseEntity {
  hourlyRateValue: string;
  hourlyRateCount: number;
}
