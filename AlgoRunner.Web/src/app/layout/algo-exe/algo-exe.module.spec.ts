import { AlgoExeModule } from './algo-exe.module';

describe('AlgoExeModule', () => {
  let algoExeModule: AlgoExeModule;

  beforeEach(() => {
    algoExeModule = new AlgoExeModule();
  });

  it('should create an instance', () => {
    expect(algoExeModule).toBeTruthy();
  });
});
