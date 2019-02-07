import { Component, OnInit } from '@angular/core';
import { Project } from './models/project';
import { Algorithm } from '../algorithm/models/algorithm';
import { ProjectsService } from './projects.service';
import { ExecutionInfo } from './models/executionInfo';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss'],
})
export class ProjectsComponent implements OnInit {

  private _hubConnection: HubConnection | undefined;
  favoriteProjects: Project[]
  resentProjects: Project[]
  projects: Project[]
  algs: Algorithm[]
  executionInfoItems: ExecutionInfo[]

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
      this.executionInfoItems = info.executionInfoList;
    }, error => { console.log('Error: ' + error.message); });
  }

  registerHub() {
    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.hubsUrl + 'execution')
      .build();

    this._hubConnection.start().catch(err => console.error(err.toString()));

    this._hubConnection.on('Finished', (algoExeId: number) => {
      this.executionInfoItems = this.executionInfoItems.filter(item=> item.id != algoExeId);
    });

    this._hubConnection.on('Started', (algoExe: ExecutionInfo) => {
      this.executionInfoItems.push(algoExe);
    });
  }

  constructor(private _service: ProjectsService) {
    this.projectsCurrentpage = 1;
    this.algsCurrentpage = 1;

  }

  ngOnInit() {
    this.getDashboardInfo();
    this.registerHub();
  }

}
