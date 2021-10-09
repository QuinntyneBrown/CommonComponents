import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PortalsComponent } from './portals.component';

const routes: Routes = [{ path: '', component: PortalsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PortalsRoutingModule { }
