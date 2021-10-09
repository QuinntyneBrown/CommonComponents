import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Portal } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class PortalService implements IPagableService<Portal> {

  uniqueIdentifierName: string = "portalId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Portal>> {
    return this._client.get<EntityPage<Portal>>(`${this._baseUrl}api/portal/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Portal[]> {
    return this._client.get<{ portals: Portal[] }>(`${this._baseUrl}api/portal`)
      .pipe(
        map(x => x.portals)
      );
  }

  public getById(options: { portalId: string }): Observable<Portal> {
    return this._client.get<{ portal: Portal }>(`${this._baseUrl}api/portal/${options.portalId}`)
      .pipe(
        map(x => x.portal)
      );
  }

  public remove(options: { portal: Portal }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/portal/${options.portal.portalId}`);
  }

  public create(options: { portal: Portal }): Observable<{ portal: Portal }> {
    return this._client.post<{ portal: Portal }>(`${this._baseUrl}api/portal`, { portal: options.portal });
  }
  
  public update(options: { portal: Portal }): Observable<{ portal: Portal }> {
    return this._client.put<{ portal: Portal }>(`${this._baseUrl}api/portal`, { portal: options.portal });
  }
}
