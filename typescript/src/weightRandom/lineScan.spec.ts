import { getRandomWeightedValue } from './lineScan';
import * as sinon from 'sinon';

describe('getRandomWeightedValue', () => {
  // Out of 1, the relative and cumulative values for these are:
  //      a: 0.1666   -> 0.16666
  //      b: 0.3333   -> 0.5
  //      c: 0.5      -> 1
  const values = { a: 10, b: 20, c: 30 };

  it('returns appropriate values for particular random value', () => {
    // any random number under 0.166666 should return "a"
    const stub1 = sinon.stub(Math, 'random').returns(0);
    const result1 = getRandomWeightedValue(values);
    expect(result1).toEqual('a');
    stub1.restore();

    const stub2 = sinon.stub(Math, 'random').returns(0.1666);
    const result2 = getRandomWeightedValue(values);
    expect(result2).toEqual('a');
    stub2.restore();

    // any random number between 0.166666 and 0.5 should return "b"
    const stub3 = sinon.stub(Math, 'random').returns(0.17);
    const result3 = getRandomWeightedValue(values);
    expect(result3).toEqual('b');
    stub3.restore();

    const stub4 = sinon.stub(Math, 'random').returns(0.3333);
    const result4 = getRandomWeightedValue(values);
    expect(result4).toEqual('b');
    stub4.restore();

    const stub5 = sinon.stub(Math, 'random').returns(0.5);
    const result5 = getRandomWeightedValue(values);
    expect(result5).toEqual('b');
    stub5.restore();

    // any random number above 0.5 should return "c"
    const stub6 = sinon.stub(Math, 'random').returns(0.500001);
    const result6 = getRandomWeightedValue(values);
    expect(result6).toEqual('c');
    stub6.restore();

    const stub7 = sinon.stub(Math, 'random').returns(1);
    const result7 = getRandomWeightedValue(values);
    expect(result7).toEqual('c');
    stub7.restore();
  });
});
