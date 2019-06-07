import {IBaseEntity} from "./IBaseEntity";
import DateTimeFormat = Intl.DateTimeFormat;

export interface IUserTask extends IBaseEntity {
  Start: DateTimeFormat;
  End: DateTimeFormat;
}
