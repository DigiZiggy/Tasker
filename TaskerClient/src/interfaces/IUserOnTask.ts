import {IBaseEntity} from "./IBaseEntity";

export interface IUserOnTask extends IBaseEntity {
  userOnTaskValue: string;
  userOnTaskCount: number;
}
