import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProjectsService } from './../projects.service';
import { Project } from '../models/project';

@Component({
  selector: 'project-ico',
  templateUrl: './project-ico.component.html',
  styleUrls: ['./project-ico.component.scss']
})
export class ProjectIcoComponent implements OnInit {

  project: Project;
  isFavoriteVisible : boolean;
  @Input() id: number;
  @Input() bgClass: string;
  @Input() icon: string;
  @Input() title: string;
  @Input() isFavorite: boolean;
  @Input() isFavoriteList: boolean;
  @Output() favoriteChangeEvent: EventEmitter<Project> = new EventEmitter<Project>();
  rr: boolean;

  addToFavorite(): void {
    this._service.addToFavorite(this.id).subscribe();
    this.isFavorite = !this.isFavorite;
    this.favoriteChangeEvent.emit(this.project);

    this.isFavoriteVisible = (this.isFavorite && this.isFavoriteList) || !this.isFavorite 
  }

  constructor(private _service: ProjectsService) {
  }

  ngOnInit() {
    this.project = new Project();
    this.project.id = this.id;
    this.project.name = this.title;
    this.project.isFavorite = this.isFavorite;

    this.isFavoriteVisible = (this.isFavorite && this.isFavoriteList) || (!this.isFavorite && !this.isFavoriteList)
  }

}
