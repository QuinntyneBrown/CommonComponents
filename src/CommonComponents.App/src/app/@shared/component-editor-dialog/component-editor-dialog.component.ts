import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ComponentService, Portal } from '@api';
import { Destroyable } from '@core';
import { BehaviorSubject } from 'rxjs';
import { map, takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-component-editor-dialog',
  templateUrl: './component-editor-dialog.component.html',
  styleUrls: ['./component-editor-dialog.component.scss']
})
export class ComponentEditorDialogComponent extends Destroyable {

  private readonly _portals$: BehaviorSubject<Portal[]> = new BehaviorSubject([]);

  public vm$ = this._portals$
  .pipe(
    map(portals => {
      const form = new FormGroup({
        portal: new FormGroup({
          name: new FormControl(null,[Validators.required])
        }),
        name: new FormControl(null, [Validators.required]),
        description: new FormControl(null, [Validators.required])
      });

      return {
        portals,
        form
      }
    })
  );

  save(component: any) {
    this._componentService.create({ component })
    .pipe(
      takeUntil(this._destroyed$)
    ).subscribe();
  }

  constructor(
    @Inject(MAT_DIALOG_DATA) _portals:Portal[],
    private readonly _componentService: ComponentService
  ) {
    super();
    this._portals$.next(_portals);
  }

}
