import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

import { AdminComponent } from './admin.component'
import { AdminRoutingModule } from './admin-routing.module';
import { ProjectsPageHeaderModule } from '../../shared/modules/projects-page-header/projects-page-header.module';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgbModule.forRoot(),
    AdminRoutingModule,
    ProjectsPageHeaderModule,
  ],
  declarations: [AdminComponent]
})
export class AdminModule { }


