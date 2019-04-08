import {IBaseEntity} from "./IBaseEntity";

export interface IReview extends IBaseEntity {
  reviewValue: string;
  reviewCount: number;
}
