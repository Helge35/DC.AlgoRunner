import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbAlertModule ,NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { ProjectsDetailRoutingModule } from './projects-detail-routing.module';
import { ProjectsDetailComponent } from './projects-detail.component';

import { ProjectsPageHeaderModule } from '../../shared/modules/projects-page-header/projects-page-header.module';
import {AlgoIcoModule} from '../algorithm/algo-ico/algo-ico.module'

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgbModule.forRoot(),
    ProjectsDetailRoutingModule,
    ProjectsPageHeaderModule,
    AlgoIcoModule
  ],
  declarations: [ProjectsDetailComponent,]
})
export class ProjectsDetailModule { }

