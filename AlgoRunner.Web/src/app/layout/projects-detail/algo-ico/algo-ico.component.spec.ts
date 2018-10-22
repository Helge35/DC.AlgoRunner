import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlgoIcoComponent } from './algo-ico.component';

describe('AlgoIcoComponent', () => {
  let component: AlgoIcoComponent;
  let fixture: ComponentFixture<AlgoIcoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlgoIcoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlgoIcoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
