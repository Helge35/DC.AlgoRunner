import { Activity } from "../../../shared/models/activity";
import { AlgResultType } from "./algResultType";
import { AlgoParam } from "./algoParam";

export class Algorithm {
    id: number;
    name: string;
    desc: string;
    activity : Activity;
    createdBy:  string;
    resultType : AlgResultType;
    algoParams: AlgoParam[];

    constructor() {
      this.algoParams=[];
    } 
  }