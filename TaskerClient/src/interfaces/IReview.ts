import {IBaseEntity} from "./IBaseEntity";

export interface IReview extends IBaseEntity {
  ReviewComment: string;
  Rating: number;
}
