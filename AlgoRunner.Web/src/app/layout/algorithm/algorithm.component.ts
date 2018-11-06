import { Component, OnInit } from '@angular/core';
import { Algorithm } from './models/algorithm';
import { Activity } from '../../shared/models/activity';
import { ResultTypesEnum } from '../../shared/models/resultTypesEnum';
import { ActivityService } from '../../shared/services/activity.service';
import { AlgResultType } from './models/algResultType';
import { KeyValue } from '@angular/common';
import { AlgoParam } from './models/algoParam';
import { AlertComponent } from '../bs-component/components';

@Component({
  selector: 'app-algorithm',
  templateUrl: './algorithm.component.html',
  styleUrls: ['./algorithm.component.scss']
})
export class AlgorithmComponent implements OnInit {

  alg: Algorithm;
  resultTypes: AlgResultType[] = ResultTypesEnum;
  activities: Activity[];
  propertyTypes: KeyValue<number, string>[]= [
    {key:1, value: "Number"},
    {key:2, value: "Text"},
    {key:3, value: "Boolean"},
  ]
  newParameter: AlgoParam;

  getActivities() {
    this._serviceActivity.getActivities().subscribe(i => this.activities = i);
  }

  addNewParameter()
  {
    this.alg.algoParams.push(this.newParameter);
    this.newParameter = new AlgoParam();
  }

  constructor(private _serviceActivity: ActivityService) { }

  ngOnInit() {
    this.alg = new Algorithm();
    this.alg.algoParams = [];
    this.newParameter = new AlgoParam();

    this.getActivities();
  }
}
