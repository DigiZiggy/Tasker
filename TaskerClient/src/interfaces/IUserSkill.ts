import {IBaseEntity} from "./IBaseEntity";

export interface IUserSkill extends IBaseEntity {
  userSkillValue: string;
  userSkillCount: number;
}
