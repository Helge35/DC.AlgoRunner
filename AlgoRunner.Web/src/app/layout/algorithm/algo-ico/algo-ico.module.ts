import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AlgoIcoComponent } from './algo-ico.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  declarations: [AlgoIcoComponent],
  exports: [AlgoIcoComponent]
})
export class AlgoIcoModule { }
