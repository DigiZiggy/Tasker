import {IBaseEntity} from "./IBaseEntity";

export interface IUserTask extends IBaseEntity {
  userTaskValue: string;
  userTaskCount: number;
}
