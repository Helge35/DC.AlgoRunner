import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AlgoExeComponent } from './algo-exe.component';

const routes: Routes = [
    {
        path: ':projectId/:id', component: AlgoExeComponent,
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AlgoExeRoutingModule {
}