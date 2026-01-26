import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterInputs } from './filter-inputs';

describe('FilterInputs', () => {
  let component: FilterInputs;
  let fixture: ComponentFixture<FilterInputs>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FilterInputs]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FilterInputs);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
