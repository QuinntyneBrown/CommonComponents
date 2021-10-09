import { TestBed } from '@angular/core/testing';

import { PortalComponentService } from './portal-component.service';

describe('PortalComponentService', () => {
  let service: PortalComponentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PortalComponentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
