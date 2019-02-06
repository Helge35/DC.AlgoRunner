import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Algorithm } from '../algorithm/models/algorithm';
import { AlgorithmService } from '../../shared/services/algorithm.service';


@Component({
  selector: 'app-algo-exe',
  templateUrl: './algo-exe.component.html',
  styleUrls: ['./algo-exe.component.scss']
})
export class AlgoExeComponent implements OnInit {

  id: number;
  projectId: number;
  algos: Algorithm[];
  accessStatus: number = 0;

  getAlg() {
    this._serviceAlgo.checkAccess(this.id).subscribe(data => {
      this.accessStatus = 200;
      this._serviceAlgo.getAlg(this.projectId, this.id).subscribe(a => {
      this.algos = a;
      });
    },
     (error) => this.accessStatus = parseInt(error.status));
  }

  runAlgorithms() {
    this._serviceAlgo.runAlgorithms(this.algos).subscribe();
    this._router.navigate(['']);
  }

  constructor(private _activatedRoute: ActivatedRoute, private _serviceAlgo: AlgorithmService, private _router: Router) { }

  ngOnInit() {
    this._activatedRoute.params.subscribe(params => { this.projectId = +params['projectId']; });
    this._activatedRoute.params.subscribe(params => { this.id = +params['id']; });
    this.getAlg();
  }
}
