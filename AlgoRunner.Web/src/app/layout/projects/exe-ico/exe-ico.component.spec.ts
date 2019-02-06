import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExeIcoComponent } from './exe-ico.component';

describe('ExeIcoComponent', () => {
  let component: ExeIcoComponent;
  let fixture: ComponentFixture<ExeIcoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExeIcoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExeIcoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
