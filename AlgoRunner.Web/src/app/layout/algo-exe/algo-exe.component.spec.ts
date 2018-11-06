import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlgoExeComponent } from './algo-exe.component';

describe('AlgoExeComponent', () => {
  let component: AlgoExeComponent;
  let fixture: ComponentFixture<AlgoExeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlgoExeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlgoExeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
