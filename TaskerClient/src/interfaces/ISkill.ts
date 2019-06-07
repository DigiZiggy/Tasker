import {IBaseEntity} from "./IBaseEntity";

export interface ISkill extends IBaseEntity {
  SkillName: string;
  Description: string;
  Category: number;
}
