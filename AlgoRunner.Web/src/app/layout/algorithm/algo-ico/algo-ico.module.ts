import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AlgoIcoComponent } from './algo-ico.component';
import { NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgbModule.forRoot(),
    RouterModule
  ],
  declarations: [AlgoIcoComponent],
  exports: [AlgoIcoComponent]
})
export class AlgoIcoModule { }
