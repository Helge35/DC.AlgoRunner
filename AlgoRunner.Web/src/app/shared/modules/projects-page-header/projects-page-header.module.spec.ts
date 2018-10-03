import { ProjectsPageHeaderModule } from './projects-page-header.module';

describe('ProjectsPageHeaderModule', () => {
  let projectsPageHeaderModule: ProjectsPageHeaderModule;

  beforeEach(() => {
    projectsPageHeaderModule = new ProjectsPageHeaderModule();
  });

  it('should create an instance', () => {
    expect(projectsPageHeaderModule).toBeTruthy();
  });
});
