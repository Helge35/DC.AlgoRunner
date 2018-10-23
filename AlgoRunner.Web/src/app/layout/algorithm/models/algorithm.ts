import { Activity } from "../../../shared/models/activity";
import { AlgResultType } from "./algResultType";

export class Algorithm {
    id: number;
    name: string;
    isFavorite : boolean;
    lastExecutionDate: Date;
    activity : Activity;
    resultType : AlgResultType
  }