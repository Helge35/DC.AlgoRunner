import {ProjectExecution} from './projectExecution';

export class Project {
    id: number;
    name: string;
    desc: string;
    createdBy : string;
    isFavorite : boolean;
    lastExecutionDate: Date;
    executionsList : ProjectExecution[];
  }