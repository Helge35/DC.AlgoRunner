import { Activity } from "../../../shared/models/activity";
import { AlgResultType } from "./algResultType";
import { AlgoParam } from "./algoParam";

export class Algorithm {
    id: number;
    name: string;
    isFavorite : boolean;
    lastExecutionDate: Date;
    activity : Activity;
    resultType : AlgResultType;
    algoParams: AlgoParam[];
  }