import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponentEditorDialogComponent } from './component-editor-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { HtmlEditorModule } from '@shared/html-editor';


@NgModule({
  declarations: [
    ComponentEditorDialogComponent
  ],
  exports: [
    ComponentEditorDialogComponent
  ],
  imports: [
    CommonModule,
    MatDialogModule,
    MatAutocompleteModule,
    MatInputModule,
    ReactiveFormsModule,
    HtmlEditorModule
  ]
})
export class ComponentEditorDialogModule { }
