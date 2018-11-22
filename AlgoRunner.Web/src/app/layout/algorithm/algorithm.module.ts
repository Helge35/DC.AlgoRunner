import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProjectsPageHeaderModule } from '../../shared/modules/projects-page-header/projects-page-header.module';
import { NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AlgorithmComponent } from './algorithm.component';
import { AlgorithmRoutingModule } from './algorithm-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgbModule.forRoot(),
    ProjectsPageHeaderModule,
    AlgorithmRoutingModule,
  ],
  declarations: [AlgorithmComponent]
})
export class AlgorithmModule { }





