import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AlgorithmComponent } from './algorithm.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
  ],
  declarations: [AlgorithmComponent]
})
export class AlgorithmModule { }
