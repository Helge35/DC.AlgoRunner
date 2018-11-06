import { Component, OnInit } from '@angular/core';
import { Algorithm } from './models/algorithm';
import { Activity } from '../../shared/models/activity';
import { ResultTypesEnum } from '../../shared/models/resultTypesEnum';
import { KeyValue } from '../../shared/models/KeyValue';
import { ActivityService } from '../../shared/services/activity.service';

@Component({
  selector: 'app-algorithm',
  templateUrl: './algorithm.component.html',
  styleUrls: ['./algorithm.component.scss']
})
export class AlgorithmComponent implements OnInit {

  alg: Algorithm;
  resultTypes: KeyValue[] = ResultTypesEnum;
  activities: Activity[];

  getActivities() {
    this._serviceActivity.getActivities().subscribe(i => this.activities = i);
  }

  constructor(private _serviceActivity: ActivityService) { }

  ngOnInit() {
    this.alg = new Algorithm();
    this.getActivities();
  }
}
