import { TestBed } from '@angular/core/testing';

import { DepatmentService } from './depatment.service';

describe('DepatmentService', () => {
  let service: DepatmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DepatmentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
