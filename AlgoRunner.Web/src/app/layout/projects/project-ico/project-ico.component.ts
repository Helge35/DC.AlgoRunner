import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'project-ico',
  templateUrl: './project-ico.component.html',
  styleUrls: ['./project-ico.component.scss']
})
export class ProjectIcoComponent implements OnInit {

    @Input() bgClass: string;
    @Input() icon: string;
    @Input() title: string;
    @Input() isFavorite: boolean;
    @Output() event: EventEmitter<any> = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

}
