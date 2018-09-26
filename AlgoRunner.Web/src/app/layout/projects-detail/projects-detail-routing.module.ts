import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjectsDetailComponent } from './projects-detail.component';

const routes: Routes = [
    {
        path: '', component: ProjectsDetailComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProjectsDetailRoutingModule {
}
