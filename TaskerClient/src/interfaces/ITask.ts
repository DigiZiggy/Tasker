import {IBaseEntity} from "./IBaseEntity";

export interface ITask extends IBaseEntity {
  TaskName: string;
  Description: string;
  TimeEstimate: number;
  TaskType: number;
  TaskStatus: number;
}
