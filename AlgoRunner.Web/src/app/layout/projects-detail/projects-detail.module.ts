import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ProjectsDetailRoutingModule } from './projects-detail-routing.module';
import { ProjectsDetailComponent } from './projects-detail.component';

import { ProjectsPageHeaderModule } from '../../shared/modules/projects-page-header/projects-page-header.module';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ProjectsDetailRoutingModule,
    ProjectsPageHeaderModule,
  ],
  declarations: [ProjectsDetailComponent,]
})
export class ProjectsDetailModule { }

