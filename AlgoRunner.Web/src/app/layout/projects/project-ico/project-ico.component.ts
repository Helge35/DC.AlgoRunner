import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProjectsService } from './../projects.service';
import { Project } from '../models/project';
import { Activity } from '../../../shared/models/activity';
import { Alert } from 'selenium-webdriver';

@Component({
  selector: 'project-ico',
  templateUrl: './project-ico.component.html',
  styleUrls: ['./project-ico.component.scss']
})
export class ProjectIcoComponent implements OnInit {

  project: Project;
  isFavoriteVisible: boolean;
  @Input() id: number;
  @Input() title: string;
  @Input() isFavorite: boolean;
  @Input() isFavoriteList: boolean;
  @Input() activityName: string;
  @Input() intoFavorites: boolean;

  @Output() favoriteChangeEvent: EventEmitter<Project> = new EventEmitter<Project>();
  @Output() removeProjectChangeEvent: EventEmitter<number> = new EventEmitter<number>();

  accessStatus: number = 0;
  
  addToFavorite(): void {
    this._service.addToFavorite(this.id).subscribe(i =>
      this.favoriteChangeEvent.emit(this.project)
    );
  }

  removeActivity(): void {
    if (confirm("Are you sure to delete activity")) {
      this._service.deleteProject(this.project.id).subscribe(i =>{
        this.removeProjectChangeEvent.emit(this.project.id)
      },
      (error) => alert("You can't remove this project, call to administrator"));
    }
  }

  constructor(private _service: ProjectsService) {
  }

  ngOnInit() {
    this.project = new Project();
    this.project.id = this.id;
    this.project.name = this.title;
    this.project.isFavorite = this.isFavorite;
    this.project.activity = new Activity();
    this.project.activity.name = this.activityName;
  }

}
