import { Project } from './project';
import { Activity } from '../../../shared/models/activity';
import { Algorithm } from '../../algorithm/models/algorithm';
import { ExecutionInfo } from './executionInfo';

export class DashboardInfo {
  favoriteList: Project[];
  resentList: Project[];
  allList: Project[];
  projectsTotalSize : number;
  algorithmsList : Algorithm[];
  algorithmsTotalSize : number;
  activitiesList : Activity[];
  executionInfoList : ExecutionInfo[];
}