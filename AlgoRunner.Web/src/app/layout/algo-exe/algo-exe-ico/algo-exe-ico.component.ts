import { Component, OnInit, Input } from '@angular/core';
import { Algorithm } from '../../algorithm/models/algorithm';

@Component({
  selector: 'algo-exe-ico',
  templateUrl: './algo-exe-ico.component.html',
  styleUrls: ['./algo-exe-ico.component.scss']
})
export class AlgoExeIcoComponent implements OnInit {

  @Input() algo: Algorithm;


  constructor() { }

  ngOnInit() {
  }

}
