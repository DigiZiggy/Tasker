import {IBaseEntity} from "./IBaseEntity";

export interface ITask extends IBaseEntity {
  taskValue: string;
  taskCount: number;
}
