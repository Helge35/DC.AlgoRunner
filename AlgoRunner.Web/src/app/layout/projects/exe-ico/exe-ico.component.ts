import { Component, OnInit, Input } from '@angular/core';
import { ExecutionInfo } from '../models/executionInfo';

@Component({
  selector: 'exe-ico',
  templateUrl: './exe-ico.component.html',
  styleUrls: ['./exe-ico.component.scss']
})
export class ExeIcoComponent implements OnInit {

  @Input() exeInfo: ExecutionInfo;

  /*timeOver: string;
  interval;
*/

 /* startTimer() {
    this.timeOver = "00 : 00";
    this.interval = setInterval(() => {
      var minutes = Math.round( Math.abs(new Date().getTime() - new Date(this.exeInfo.startDate).getTime())/60000);
      var hr= Math.floor( minutes / 60).toString();
      if(hr.length ==1 ){
        hr = "0"+hr;
      }
      var min = Math.floor( minutes % 60).toString();
      if(min.length ==1 ){
        min = "0"+min;
      }

      this.timeOver = hr + " : "  + min;
    }, 1000)
  }*/

  constructor() { }

  ngOnInit() {
    //this.startTimer();
    if( this.exeInfo.executedBy.includes("\\"))
      this.exeInfo.executedBy = this.exeInfo.executedBy.split("\\")[1]
  }
}
