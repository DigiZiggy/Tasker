import {IBaseEntity} from "./IBaseEntity";

export interface ISkill extends IBaseEntity {
  skillValue: string;
  skillCount: number;
}
