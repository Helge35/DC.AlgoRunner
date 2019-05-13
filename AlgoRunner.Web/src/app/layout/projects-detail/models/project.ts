import {ProjectExecution} from './projectExecution';
import { Algorithm } from '../../algorithm/models/algorithm';
import { Activity } from '../../../shared/models/activity';

export class Project {
    id: number;
    name: string;
    desc: string;
    isFavorite : boolean;
    lastExecutionDate: Date;
    projectExecutions : ProjectExecution[];
    algorithmsList : Algorithm[];
    activity: Activity;
  }