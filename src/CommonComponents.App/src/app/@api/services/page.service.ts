import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Page } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class PageService implements IPagableService<Page> {

  uniqueIdentifierName: string = "pageId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Page>> {
    return this._client.get<EntityPage<Page>>(`${this._baseUrl}api/page/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Page[]> {
    return this._client.get<{ pages: Page[] }>(`${this._baseUrl}api/page`)
      .pipe(
        map(x => x.pages)
      );
  }

  public getById(options: { pageId: string }): Observable<Page> {
    return this._client.get<{ page: Page }>(`${this._baseUrl}api/page/${options.pageId}`)
      .pipe(
        map(x => x.page)
      );
  }

  public remove(options: { page: Page }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/page/${options.page.pageId}`);
  }

  public create(options: { page: Page }): Observable<{ page: Page }> {
    return this._client.post<{ page: Page }>(`${this._baseUrl}api/page`, { page: options.page });
  }
  
  public update(options: { page: Page }): Observable<{ page: Page }> {
    return this._client.put<{ page: Page }>(`${this._baseUrl}api/page`, { page: options.page });
  }
}
