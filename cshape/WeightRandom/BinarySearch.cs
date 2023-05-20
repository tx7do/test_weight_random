using WeightRandom.Interfaces;

namespace WeightRandom
{
    public class BinarySearch<T> : IRandomSelector<T>
    {
        private System.Random _random;
        private T[] _items;
        private float[] _cda;

        /// <summary>
        /// Constructor, used by StaticRandomSelectorBuilder
        /// Needs array of items and CDA (Cummulative Distribution Array). 
        /// </summary>
        /// <param name="items">Items of type T</param>
        /// <param name="cda">Cummulative Distribution Array</param>
        /// <param name="seed">Seed for internal random generator</param>
        public BinarySearch(T[] items, float[] cda, int seed)
        {
            this._items = items;
            this._cda = cda;
            this._random = new System.Random(seed);
        }

        /// <summary>
        /// Selects random item based on their weights.
        /// Uses binary search for random selection.
        /// </summary>
        /// <returns>Returns item</returns>
        public T SelectRandomItem()
        {
            var randomValue = (float) _random.NextDouble();

            return _items[_cda.SelectIndexBinarySearch(randomValue)];
        }

        /// <summary>
        /// Selects random item based on their weights.
        /// Uses binary search for random selection.
        /// </summary>
        /// <param name="randomValue">Random value from your uniform generator</param>
        /// <returns>Returns item</returns>
        public T SelectRandomItem(float randomValue)
        {
            return _items[_cda.SelectIndexBinarySearch(randomValue)];
        }
    }
}