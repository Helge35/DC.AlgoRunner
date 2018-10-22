import { Activity } from "../../../shared/models/activity";

export class Algorithm {
    id: number;
    name: string;
    isFavorite : boolean;
    lastExecutionDate: Date;
    activity : Activity;
  }