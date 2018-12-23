import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'projects-page-header',
  templateUrl: './projects-page-header.component.html',
  styleUrls: ['./projects-page-header.component.scss']
})
export class ProjectsPageHeaderComponent implements OnInit {

  @Input() header: string;
  @Input() staticHeader: string;
  
  constructor() { }

  ngOnInit() {
  }

}
