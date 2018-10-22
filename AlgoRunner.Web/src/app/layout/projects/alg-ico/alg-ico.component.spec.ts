import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlgIcoComponent } from './alg-ico.component';

describe('AlgIcoComponent', () => {
  let component: AlgIcoComponent;
  let fixture: ComponentFixture<AlgIcoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlgIcoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlgIcoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
