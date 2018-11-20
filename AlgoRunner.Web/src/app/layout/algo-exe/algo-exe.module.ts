import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { ProjectsPageHeaderModule } from '../../shared/modules/projects-page-header/projects-page-header.module';

import { AlgoExeComponent } from './algo-exe.component';
import { AlgoExeRoutingModule } from './algo-exe-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgbModule.forRoot(),
    AlgoExeRoutingModule,
    ProjectsPageHeaderModule,
  ],
  declarations: [AlgoExeComponent]
})
export class AlgoExeModule { }
