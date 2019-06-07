import {IBaseEntity} from "./IBaseEntity";
import DateTimeFormat = Intl.DateTimeFormat;

export interface IIdentification extends IBaseEntity {
  DocNumber: string;
  Start: DateTimeFormat;
  End: DateTimeFormat;
  Comment: string;
}
