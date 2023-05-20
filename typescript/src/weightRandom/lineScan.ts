export type WeightedOptions = {
  [option: string]: number;
};

// Pass in an object like { a: 10, b: 4, c: 400 } and it'll return either "a", "b", or "c", factoring in their respective
// weight. So in this example, "c" is likely to be returned 400 times out of 414
export const getRandomWeightedValue = (options: WeightedOptions) => {
  const keys = Object.keys(options);
  const totalSum = keys.reduce((acc, item) => acc + options[item], 0);

  let runningTotal = 0;
  const cumulativeValues = keys.map((key) => {
    const relativeValue = options[key] / totalSum;
    const cv = {
      key,
      value: relativeValue + runningTotal
    };
    runningTotal += relativeValue;
    return cv;
  });

  const r = Math.random();
  return cumulativeValues.find(({ key, value }) => r <= value)!.key;
};
