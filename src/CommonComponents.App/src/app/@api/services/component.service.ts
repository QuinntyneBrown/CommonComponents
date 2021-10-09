import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Component } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class ComponentService implements IPagableService<Component> {

  uniqueIdentifierName: string = "componentId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Component>> {
    return this._client.get<EntityPage<Component>>(`${this._baseUrl}api/component/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Component[]> {
    return this._client.get<{ components: Component[] }>(`${this._baseUrl}api/component`)
      .pipe(
        map(x => x.components)
      );
  }

  public getById(options: { componentId: string }): Observable<Component> {
    return this._client.get<{ component: Component }>(`${this._baseUrl}api/component/${options.componentId}`)
      .pipe(
        map(x => x.component)
      );
  }

  public remove(options: { component: Component }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/component/${options.component.componentId}`);
  }

  public create(options: { component: Component }): Observable<{ component: Component }> {
    return this._client.post<{ component: Component }>(`${this._baseUrl}api/component`, { component: options.component });
  }
  
  public update(options: { component: Component }): Observable<{ component: Component }> {
    return this._client.put<{ component: Component }>(`${this._baseUrl}api/component`, { component: options.component });
  }
}
