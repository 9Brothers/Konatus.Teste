import { TestBed } from '@angular/core/testing';

import { AircraftModelService } from './aircraft-model.service';

describe('AircraftModelService', () => {
  let service: AircraftModelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AircraftModelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
