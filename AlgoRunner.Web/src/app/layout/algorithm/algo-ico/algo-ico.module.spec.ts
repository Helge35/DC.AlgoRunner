import { AlgoIcoModule } from './algo-ico.module';

describe('AlgoIcoModule', () => {
  let algoIcoModule: AlgoIcoModule;

  beforeEach(() => {
    algoIcoModule = new AlgoIcoModule();
  });

  it('should create an instance', () => {
    expect(algoIcoModule).toBeTruthy();
  });
});
