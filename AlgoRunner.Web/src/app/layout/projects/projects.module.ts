import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';

import { ProjectsdRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects.component';

@NgModule({
  imports: [
    CommonModule,
    NgbAlertModule.forRoot(),
    ProjectsdRoutingModule
  ],
  declarations: [ProjectsComponent]
})
export class ProjectsModule { }


