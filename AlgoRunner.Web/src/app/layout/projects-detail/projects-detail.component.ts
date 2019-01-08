import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Project } from './models/project';
import { ProjectsDetailService } from './projects-detail.service';
import { Activity } from '../../shared/models/activity';
import { ActivityService } from '../../shared/services/activity.service';
import { Algorithm } from '../algorithm/models/algorithm';

@Component({
  selector: 'app-projects-detail',
  templateUrl: './projects-detail.component.html',
  styleUrls: ['./projects-detail.component.scss']
})
export class ProjectsDetailComponent implements OnInit {

  id: number;
  project: Project;
  activities: Activity[];
  algs: Algorithm[];

  getProject() {
    this.http.getProject(this.id).subscribe(info => {
      this.project = info;
    },
      error => { console.log('Error: ' + error.message); }
    );
  }

  getActivities() {
    this._serviceActivity.getActivities().subscribe(i => this.activities = i);
  }

  loadAlgs(page: number) {
    this.http.loadAlgsData(page).subscribe(info => {
      this.algs = info;
    }, error => { console.log('Error: ' + error.message); });
  }

  addAlgToProject(alg: Algorithm) {
    this.project.algorithmsList.push(alg);
  }

  removeAlgFromProject(alg: Algorithm){
    this.project.algorithmsList =this.project.algorithmsList.filter(item=> item != alg);
  }

  execiteProject(id : number){
    this.http.execiteProject(id).subscribe();
  }

  saveProject(proj : Project){
    this.http.saveProject(proj).subscribe();
  }

  constructor(private route: ActivatedRoute, private http: ProjectsDetailService, private _serviceActivity: ActivityService) { }

  ngOnInit() {
    this.route.params.subscribe(params => { this.id = +params['id']; });
    if (this.id) {
      this.getProject();
    } else {
      this.project = new Project();
      this.project.algorithmsList = [];
      this.getActivities();
      this.loadAlgs(1);
    }
  }

}
