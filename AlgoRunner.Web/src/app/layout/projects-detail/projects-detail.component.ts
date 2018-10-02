import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Project } from './models/project';
import { ProjectsDetailService } from './projects-detail.service';

@Component({
  selector: 'app-projects-detail',
  templateUrl: './projects-detail.component.html',
  styleUrls: ['./projects-detail.component.scss']
})
export class ProjectsDetailComponent implements OnInit {

  id: number;
  project: Project;

  getProject() {
    if (this.id) {
      this.http.getProject(this.id).subscribe(info => { this.project = info; },
        error => { console.log('Error: ' + error.message); });
    }
  }

  constructor(private route: ActivatedRoute, private http: ProjectsDetailService) { }

  ngOnInit() {

    this.route.params.subscribe(params => { this.id = +params['id']; });
    this.getProject();
  }

}
