import { AlgorithmModule } from './algorithm.module';

describe('AlgorithmModule', () => {
  let algorithmModule: AlgorithmModule;

  beforeEach(() => {
    algorithmModule = new AlgorithmModule();
  });

  it('should create an instance', () => {
    expect(algorithmModule).toBeTruthy();
  });
});
