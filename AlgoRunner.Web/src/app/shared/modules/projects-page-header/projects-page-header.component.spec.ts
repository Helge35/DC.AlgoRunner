import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectsPageHeaderComponent } from './projects-page-header.component';

describe('ProjectsPageHeaderComponent', () => {
  let component: ProjectsPageHeaderComponent;
  let fixture: ComponentFixture<ProjectsPageHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectsPageHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectsPageHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
