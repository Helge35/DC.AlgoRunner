import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectIcoComponent } from './project-ico.component';

describe('ProjectIcoComponent', () => {
  let component: ProjectIcoComponent;
  let fixture: ComponentFixture<ProjectIcoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectIcoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectIcoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
