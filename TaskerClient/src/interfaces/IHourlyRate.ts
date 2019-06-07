import {IBaseEntity} from "./IBaseEntity";
import DateTimeFormat = Intl.DateTimeFormat;

export interface IHourlyRate extends IBaseEntity {
  HourRate: number;
  Start: DateTimeFormat;
  End: DateTimeFormat;
}
