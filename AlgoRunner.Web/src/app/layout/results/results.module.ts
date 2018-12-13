import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ChartsModule as Ng2Charts } from 'ng2-charts';

import { ProjectsPageHeaderModule } from '../../shared/modules/projects-page-header/projects-page-header.module';
import { ResultsRoutingModule } from './results-routing.module';
import { ResultsComponent } from './results.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgbModule.forRoot(),
    ProjectsPageHeaderModule,
    ResultsRoutingModule,
    Ng2Charts,
  ],
  declarations: [ResultsComponent]
})
export class ResultsModule { }