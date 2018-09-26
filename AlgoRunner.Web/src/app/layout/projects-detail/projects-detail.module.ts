import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ProjectsDetailRoutingModule } from './projects-detail-routing.module';
import { ProjectsDetailComponent } from './projects-detail.component';

import { PageHeaderModule } from '../../shared';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ProjectsDetailRoutingModule,
    PageHeaderModule,
  ],
  declarations: [ProjectsDetailComponent,]
})
export class ProjectsDetailModule { }

