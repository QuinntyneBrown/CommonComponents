import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponentsRoutingModule } from './components-routing.module';
import { HtmlEditorModule } from '@shared/html-editor';
import { ComponentListComponent } from './component-list/component-list.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    ComponentListComponent
  ],
  imports: [
    CommonModule,
    ComponentsRoutingModule,
    HtmlEditorModule,
    MatAutocompleteModule,
    MatInputModule
  ]
})
export class ComponentsModule { }
