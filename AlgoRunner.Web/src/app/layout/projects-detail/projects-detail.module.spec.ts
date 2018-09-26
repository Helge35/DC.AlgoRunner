import { ProjectsDetailModule } from './projects-detail.module';

describe('ProjectsDetailModule', () => {
  let projectsDetailModule: ProjectsDetailModule;

  beforeEach(() => {
    projectsDetailModule = new ProjectsDetailModule();
  });

  it('should create an instance', () => {
    expect(projectsDetailModule).toBeTruthy();
  });
});
