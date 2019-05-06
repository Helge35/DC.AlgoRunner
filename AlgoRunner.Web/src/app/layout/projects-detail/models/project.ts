import {ProjectExecution} from './projectExecution';
import { Algorithm } from '../../algorithm/models/algorithm';

export class Project {
    id: number;
    name: string;
    desc: string;
    createdBy : string;
    isFavorite : boolean;
    lastExecutionDate: Date;
    projectExecutions : ProjectExecution[];
    algorithmsList : Algorithm[]
  }