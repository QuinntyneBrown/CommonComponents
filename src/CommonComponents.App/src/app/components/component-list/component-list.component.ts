import { Component, OnInit } from '@angular/core';
import { ComponentService, PortalService } from '@api';
import { combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-component-list',
  templateUrl: './component-list.component.html',
  styleUrls: ['./component-list.component.scss']
})
export class ComponentListComponent {

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
    private readonly _portalService: PortalService
  ) { }

  cities = [
    {id: 1, name: 'City1'},
    {id: 2, name: 'City2'},
    {id: 3, name: 'City3'},
    {id: 4, name: 'City4'},
    {id: 5, name: 'City5'}
  ];

}
