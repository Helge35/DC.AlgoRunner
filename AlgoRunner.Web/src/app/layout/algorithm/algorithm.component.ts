import { Component, OnInit, NgModuleRef } from '@angular/core';
import { Algorithm } from './models/algorithm';
import { Activity } from '../../shared/models/activity';
import { ResultTypesEnum } from '../../shared/models/resultTypesEnum';
import { ActivityService } from '../../shared/services/activity.service';
import { AlgResultType } from './models/algResultType';
import { KeyValue } from '@angular/common';
import { AlgoParam } from './models/algoParam';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { PropertyTypesEnum } from '../../shared/models/propertyTypesEnum';
import { Router } from '@angular/router';
import { AlgorithmService } from '../../shared/services/algorithm.service';



@Component({
  selector: 'app-algorithm',
  templateUrl: './algorithm.component.html',
  styleUrls: ['./algorithm.component.scss']
})
export class AlgorithmComponent implements OnInit {

  alg: Algorithm;
  resultTypes: AlgResultType[] = ResultTypesEnum;
  activities: Activity[];
  propertyTypes: KeyValue<number, string>[] = PropertyTypesEnum;
  newParameter: AlgoParam;
  fileToUpload: File = null;
  enumList: string[] = [];
  newEnum: string;
  avtiveModal: NgbActiveModal;
  updatedParam: AlgoParam;
  algoFile: File;

  getActivities() {
    this._serviceActivity.getActivities().subscribe(i => this.activities = i);
  }

  addNewParameter() {
    this.alg.algoParams.push(this.newParameter);
    this.newParameter = new AlgoParam();
    this.enumList = [];
    this.newEnum = '';
  }

  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
  }

  openModal(content, param: AlgoParam) {
    this.updatedParam = param;
    this.enumList = param.range;
    this.avtiveModal = this.modalService.open(content);
  }

  addEnumValue() {
    this.enumList.push(this.newEnum);
    this.newEnum = '';
  }

  addEnumListToProperty() {
    this.avtiveModal.dismiss();
    this.updatedParam.range = this.enumList;
  }


  uploadAndSaveAlg() {
    let activityID: number = 0;

    if (this.alg.activity) {
      activityID = this.alg.activity.id;
    }

    this._serviceAlgo.uploadAlg(this.algoFile, activityID).subscribe(
      data => {
        this.alg.fileServerPath = data;
        this._serviceAlgo.saveAlg(this.alg).subscribe();
        this._route.navigate(['']);
    },
      error => alert(error)
    );

  }


  fileChange(event) {
    let fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      this.algoFile = fileList[0];
    }
  }

  constructor(private _serviceActivity: ActivityService,
    private _serviceAlgo: AlgorithmService,
    private modalService: NgbModal,
    private _route: Router) {

  }

  ngOnInit() {
    this.alg = new Algorithm();
    this.newParameter = new AlgoParam();

    this.getActivities();
  }
}
