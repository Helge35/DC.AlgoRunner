import { Component, OnInit } from '@angular/core';
import { ActivatedRoute , Router} from '@angular/router';
import { Project } from './models/project';
import { ProjectsDetailService } from './projects-detail.service';
import { Activity } from '../../shared/models/activity';
import { ActivityService } from '../../shared/services/activity.service';
import { Algorithm } from '../algorithm/models/algorithm';
import { ProjectsService } from '../projects/projects.service';

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
  submitted : boolean =false;
  algsCurrentpage: number
  algsTotalItems: number

  getProject() {
    this.http.getProject(this.id).subscribe(info =>  this.project = info)
  }

  getActivities() {
    this._serviceActivity.getActivities().subscribe(i => this.activities = i);
  }


  addAlgToProject(alg: Algorithm) {
    this.project.algorithmsList.push(alg);
    this.filterAlgs();
  }

  removeAlgFromProject(alg: Algorithm){
    this.project.algorithmsList =this.project.algorithmsList.filter(item=> item != alg);
    this.algs.find(a => a.id == alg.id).isAttached = false;
    this.filterAlgs();
  }


  saveProject({ valid }: { valid: boolean }) {

    this.submitted = true;
    if (!valid) { return }
    this.http.saveProject(this.project).subscribe(()=>{this.route.navigate([''])});
  }

  loadPageAlgs(page: number) {
    this._projectsService.loadAlgsData(page).subscribe(info => {
      this.algs = info.algorithmsList;

      this.filterAlgs();

      this.algsTotalItems = info.algorithmsTotalSize;
    }, error => { console.log('Error: ' + error.message); });
  }

  filterAlgs()
  {
    this.project.algorithmsList.forEach(alg => {
      this.algs.find(a => a.id == alg.id).isAttached = true;
    });
  }

  constructor(private activeRoute: ActivatedRoute, private route: Router,  private http: ProjectsDetailService, private _projectsService: ProjectsService, private _serviceActivity: ActivityService) {
    this.algsCurrentpage = 1;
   }

  ngOnInit() {
    this.activeRoute.params.subscribe(params => { this.id = +params['id']; });
    if (this.id) {
      this.getProject();
    } else {
      this.project = new Project();
      this.project.algorithmsList = [];
      this.getActivities();
      this.loadPageAlgs(1);
    }
  }

}
