import {IBaseEntity} from "./IBaseEntity";
import DateTimeFormat = Intl.DateTimeFormat;

export interface IUserSkill extends IBaseEntity {
  Start: DateTimeFormat;
  End: DateTimeFormat;
}
