import {IBaseEntity} from "./IBaseEntity";
import DateTimeFormat = Intl.DateTimeFormat;

export interface IUserOnAddress extends IBaseEntity {
  Start: DateTimeFormat;
  End: DateTimeFormat;
}
