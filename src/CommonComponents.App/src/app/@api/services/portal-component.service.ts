import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PortalComponent } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class PortalComponentService implements IPagableService<PortalComponent> {

  uniqueIdentifierName: string = "portalComponentId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<PortalComponent>> {
    return this._client.get<EntityPage<PortalComponent>>(`${this._baseUrl}api/portalComponent/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<PortalComponent[]> {
    return this._client.get<{ portalComponents: PortalComponent[] }>(`${this._baseUrl}api/portalComponent`)
      .pipe(
        map(x => x.portalComponents)
      );
  }

  public getById(options: { portalComponentId: string }): Observable<PortalComponent> {
    return this._client.get<{ portalComponent: PortalComponent }>(`${this._baseUrl}api/portalComponent/${options.portalComponentId}`)
      .pipe(
        map(x => x.portalComponent)
      );
  }

  public remove(options: { portalComponent: PortalComponent }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/portalComponent/${options.portalComponent.portalComponentId}`);
  }

  public create(options: { portalComponent: PortalComponent }): Observable<{ portalComponent: PortalComponent }> {
    return this._client.post<{ portalComponent: PortalComponent }>(`${this._baseUrl}api/portalComponent`, { portalComponent: options.portalComponent });
  }
  
  public update(options: { portalComponent: PortalComponent }): Observable<{ portalComponent: PortalComponent }> {
    return this._client.put<{ portalComponent: PortalComponent }>(`${this._baseUrl}api/portalComponent`, { portalComponent: options.portalComponent });
  }
}
