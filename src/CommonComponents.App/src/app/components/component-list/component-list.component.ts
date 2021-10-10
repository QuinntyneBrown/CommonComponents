import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ComponentService, Portal, PortalService } from '@api';
import { Destroyable } from '@core';
import { ComponentEditorDialogComponent } from '@shared/component-editor-dialog/component-editor-dialog.component';
import { combineLatest } from 'rxjs';
import { map, takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-component-list',
  templateUrl: './component-list.component.html',
  styleUrls: ['./component-list.component.scss']
})
export class ComponentListComponent extends Destroyable {

  public vm$ = combineLatest([
    this._componentService.get(),
    this._portalService.get()
  ])
  .pipe(
    map(([components, portals]) => {
      return {
        components,
        portals
      };
    })
  )

  constructor(
    private readonly _componentService: ComponentService,
    private readonly _portalService: PortalService,
    private readonly _dialog: MatDialog
  ) {
    super();
  }

  open(portals: Portal[]) {
    this._dialog.open(ComponentEditorDialogComponent, {
      data: portals
    })
    .afterClosed()
    .pipe(
      takeUntil(this._destroyed$)
    ).subscribe();
  }
}
