import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'alg-ico',
  templateUrl: './alg-ico.component.html',
  styleUrls: ['./alg-ico.component.scss']
})
export class AlgIcoComponent implements OnInit {

  @Input() id: number;
  @Input() title: string;
  @Input() activityName: string;

  constructor() { }

  ngOnInit() {
  }

}
