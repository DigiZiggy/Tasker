import {IBaseEntity} from "./IBaseEntity";

export interface ITaskType extends IBaseEntity {
  taskTypeValue: string;
  taskTypeCount: number;
}
