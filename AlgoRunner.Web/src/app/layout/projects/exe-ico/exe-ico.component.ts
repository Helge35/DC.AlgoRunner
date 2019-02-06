import { Component, OnInit, Input } from '@angular/core';
import { ExecutionInfo } from '../models/executionInfo';

@Component({
  selector: 'exe-ico',
  templateUrl: './exe-ico.component.html',
  styleUrls: ['./exe-ico.component.scss']
})
export class ExeIcoComponent implements OnInit {

  @Input() exeInfo: ExecutionInfo;

  timeOver: number;
  interval;


  startTimer() {
    this.interval = setInterval(() => {
      this.timeOver = new Date().getTime() - new Date(this.exeInfo.startDate).getTime();
    }, 1000)
  }

  constructor() { }

  ngOnInit() {
    this.startTimer();
  }
}
