import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponentsRoutingModule } from './components-routing.module';
import { ComponentListComponent } from './component-list/component-list.component';
import { MatButtonModule } from '@angular/material/button';
import { ComponentEditorDialogModule } from '@shared/component-editor-dialog/component-editor-dialog.module';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    ComponentListComponent
  ],
  imports: [
    CommonModule,
    ComponentsRoutingModule,
    ComponentEditorDialogModule,
    MatButtonModule,
    MatDialogModule
  ]
})
export class ComponentsModule { }
