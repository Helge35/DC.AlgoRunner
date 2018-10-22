import { Activity } from "../../../shared/models/activity";

export class Project {
    id: number;
    name: string;
    isFavorite : boolean;
    lastExecutionDate: Date;
    activity : Activity;
  }