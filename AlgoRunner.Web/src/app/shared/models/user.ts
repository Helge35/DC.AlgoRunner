import { Activity } from "./activity";

export class User {
    id: number;
    name: string;
    activities : Activity[];
    isAdmin: boolean;
  }