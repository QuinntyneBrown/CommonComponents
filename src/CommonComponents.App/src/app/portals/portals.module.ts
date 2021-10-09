import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PortalsRoutingModule } from './portals-routing.module';
import { PortalsComponent } from './portals.component';


@NgModule({
  declarations: [
    PortalsComponent
  ],
  imports: [
    CommonModule,
    PortalsRoutingModule
  ]
})
export class PortalsModule { }
