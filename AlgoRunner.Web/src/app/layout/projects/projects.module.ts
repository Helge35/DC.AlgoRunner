import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbAlertModule ,NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

import { ProjectsdRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects.component';
import { ProjectIcoComponent } from './project-ico/project-ico.component';
import { ProjectsService } from './projects.service';

import { PageHeaderModule } from '../../shared';

@NgModule({
  imports: [
    CommonModule,
    ProjectsdRoutingModule,
    NgbAlertModule.forRoot(),
    FormsModule,
    NgbModule.forRoot(),
    PageHeaderModule,
  ],
  declarations: [ProjectsComponent, ProjectIcoComponent],
  providers:[ProjectsService]
})
export class ProjectsModule { }


