import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlgoExeIcoComponent } from './algo-exe-ico.component';

describe('AlgoExeIcoComponent', () => {
  let component: AlgoExeIcoComponent;
  let fixture: ComponentFixture<AlgoExeIcoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlgoExeIcoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlgoExeIcoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
