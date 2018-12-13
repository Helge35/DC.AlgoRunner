import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlgoResultDotesGraph } from './models/algoResultDotesGraph';
import { ResultsService } from './results.service';


@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss']
})
export class ResultsComponent implements OnInit {

  public algoName: string;
  public scatterData: AlgoResultDotesGraph;
  public chartColors: Array<any> = [
    {
      backgroundColor: 'rgba(0,128,0,1)',
      pointRadius: 2
    },
    {
      backgroundColor: 'rgba(255,0,0,1)',
      pointRadius: 2
    },
    {
      backgroundColor: 'rgba(72,0,255,1)',
      pointRadius: 2
    },
    {
      backgroundColor: 'rgba(255,233,127,1)',
      pointRadius: 2
    },
    {
      backgroundColor: 'rgba(255,0,110,1)',
      pointRadius: 2
    },
  ];

  public ScatterchartOptions: any = {
    responsive: true,
    legend: {
      position: 'bottom'
    },
    scales: {
      xAxes: [{
        type: 'linear',
        position: 'bottom'
      }]
    }
  };

  getGraphData(path: string) {
    this._service.getResultByPath(path).subscribe(res=>{
      this.scatterData = res;
    });
  }

  constructor(private _service: ResultsService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(par => {
      let path: string = par.get('path');
      this.getGraphData(path);
    });
  }

}
