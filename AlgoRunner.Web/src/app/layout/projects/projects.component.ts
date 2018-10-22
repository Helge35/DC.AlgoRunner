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
    this.algsCurrentpage = 1;

  }

  ngOnInit() {
    this.getDashboardInfo();
  }

}
