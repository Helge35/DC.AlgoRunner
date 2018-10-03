import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ProjectsPageHeaderComponent } from './projects-page-header.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  declarations: [ProjectsPageHeaderComponent],
  exports: [ProjectsPageHeaderComponent]
})
export class ProjectsPageHeaderModule { }
