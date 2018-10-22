import { Component, OnInit } from '@angular/core';
import { Project } from './models/project';
import { Algorithm } from '../algorithm/models/algorithm';
import { ProjectsService } from './projects.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss'],
})
export class ProjectsComponent implements OnInit {

  favoriteProjects: Project[]
  resentProjects: Project[]
  projects: Project[]
  algs: Algorithm[]

  projectsCurrentpage: number
  progectsTotalItems: number

  algsCurrentpage: number
  algsTotalItems: number



  onFavoriteChanged(proj: Project, ) {

    if (proj.isFavorite == true)//remove
    {
      this.favoriteProjects = this.favoriteProjects.filter(item => item.id !== proj.id);
    }
    else//add
    {
      this.favoriteProjects.push(proj);
    }
  }

  loadPageAlgs(page: number) {
    this._service.loadAlgsData(page).subscribe(info => {
      this.algs = info.algorithmsList;
      this.algsTotalItems = info.algorithmsTotalSize;
    }, error => { console.log('Error: ' + error.message); });
  }

  loadPage(page: number) {
    this._service.loadProjectData(page).subscribe(info => {
      this.projects = info.allList;
      this.progectsTotalItems = info.projectsTotalSize;
    }, error => { console.log('Error: ' + error.message); });
  }


  getDashboardInfo(): void {
    this._service.getDashboardInfo().subscribe(info => {
      this.projects = info.allList;
      this.favoriteProjects = info.favoriteList;
      this.resentProjects = info.resentList;
      this.progectsTotalItems = info.projectsTotalSize;
      this.algs = info.algorithmsList;
      this.algsTotalItems = info.algorithmsTotalSize;
    }, error => { console.log('Error: ' + error.message); });
  }

  constructor(private _service: ProjectsService) {
    this.projectsCurrentpage = 1;

  }

  ngOnInit() {

    this.getDashboardInfo();

    /* this.projects=[
       {id: 1, name:'Proj 1', isFavorite:true, lastExecutionDate : new Date(2011, 0, 1, 0, 0, 0, 0)},
       {id: 2, name:'Proj 2', isFavorite:false, lastExecutionDate :new Date(2011, 0, 1, 0, 0, 0, 0)},
       {id: 3, name:'Proj 3', isFavorite:true, lastExecutionDate :new Date(2011, 0, 1, 0, 0, 0, 0)},
       {id: 5, name:'Proj 5', isFavorite:true, lastExecutionDate :new Date(2011, 0, 1, 0, 0, 0, 0)},
       {id: 6, name:'Proj 6', isFavorite:false, lastExecutionDate :new Date(2011, 0, 1, 0, 0, 0, 0)},
       {id: 7, name:'Proj 7', isFavorite:false, lastExecutionDate :new Date(2011, 0, 1, 0, 0, 0, 0)},
       {id: 8, name:'Proj 8', isFavorite:true, lastExecutionDate :new Date(2011, 0, 11, 0, 0, 0, 0)},
       {id: 9, name:'Proj 9', isFavorite:false, lastExecutionDate :new Date(2011, 0, 10, 0, 0, 0, 0)},
       {id: 10, name:'Proj 10', isFavorite:false, lastExecutionDate :new Date(2011, 0, 5, 0, 0, 0, 0)},
       {id: 11, name:'Proj 11', isFavorite:false, lastExecutionDate :new Date(2011, 0, 6, 0, 0, 0, 0)},
       {id: 12, name:'Proj 12', isFavorite:true, lastExecutionDate :new Date(2011, 0, 7, 0, 0, 0, 0)},
       {id: 12, name:'Proj 13', isFavorite:false, lastExecutionDate :new Date(2011, 0, 8, 0, 0, 0, 0)},
     ];
 
     this.favoriteProjects=this.projects.filter(pr=>pr.isFavorite=== true);
 
     this.resentProjects = this.projects.filter(m => m.lastExecutionDate>new Date(2011, 0, 1, 0, 0, 0, 0) );*/
  }

}
