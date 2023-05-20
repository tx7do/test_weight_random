using System.Collections.Generic;

namespace WeightRandom
{
    public static class RandomMath
    {
        /// <summary>
        /// Breaking point between using Linear vs. Binary search for arrays (StaticSelector). 
        /// Was calculated empirically.
        /// </summary>
        public static readonly int ArrayBreakpoint = 51;

        /// <summary>
        /// Breaking point between using Linear vs. Binary search for lists (DynamicSelector). 
        /// Was calculated empirically. 
        /// </summary>
        public static readonly int ListBreakpoint = 26;

        /// <summary>
        /// Builds cummulative distribution out of non-normalized weights inplace.
        /// </summary>
        /// <param name="cdl">List of Non-normalized weights</param>
        public static void BuildCumulativeDistribution(List<float> cdl)
        {
            var length = cdl.Count;

            // Use double for more precise calculation
            double sum = 0;

            // Sum of weights
            for (var i = 0; i < length; i++)
            {
                sum += cdl[i];
            }

            // k is normalization constant
            // calculate inverse of sum and convert to float
            // use multiplying, since it is faster than dividing      
            var k = (1f / sum);

            sum = 0;

            // Make Cummulative Distribution Array
            for (var i = 0; i < length; i++)
            {
                sum += cdl[i] * k; //k, the normalization constant is applied here
                cdl[i] = (float) sum;
            }

            cdl[length - 1] =
                1f; //last item of CDA is always 1, I do this because numerical inaccurarcies add up and last item probably wont be 1
        }

        /// <summary>
        /// Builds cummulative distribution out of non-normalized weights inplace.
        /// </summary>
        /// <param name="cda">Array of Non-normalized weights</param>
        public static void BuildCumulativeDistribution(float[] cda)
        {
            var length = cda.Length;

            // Use double for more precise calculation
            double sum = 0;

            // Sum of weights
            for (var i = 0; i < length; i++)
            {
                sum += cda[i];
            }

            // k is normalization constant
            // calculate inverse of sum and convert to float
            // use multiplying, since it is faster than dividing   
            var k = (1f / sum);

            sum = 0;

            // Make Cummulative Distribution Array
            for (var i = 0; i < length; i++)
            {
                sum += cda[i] * k; //k, the normalization constant is applied here
                cda[i] = (float) sum;
            }

            cda[length - 1] =
                1f; //last item of CDA is always 1, I do this because numerical inaccurarcies add up and last item probably wont be 1
        }


        /// <summary>
        /// Linear search, good/faster for small arrays
        /// </summary>
        /// <param name="cda">Cummulative Distribution Array</param>
        /// <param name="randomValue">Uniform random value</param>
        /// <returns>Returns index of an value inside CDA</returns>
        public static int SelectIndexLinearSearch(this float[] cda, float randomValue)
        {
            var i = 0;

            // last element, CDA[CDA.Length-1] should always be 1
            while (cda[i] < randomValue)
            {
                i++;
            }

            return i;
        }


        /// <summary>
        /// Binary search, good/faster for big array
        /// Code taken out of C# array.cs Binary Search & modified
        /// </summary>
        /// <param name="cda">Cummulative Distribution Array</param>
        /// <param name="randomValue">Uniform random value</param>
        /// <returns>Returns index of an value inside CDA</returns>
        public static int SelectIndexBinarySearch(this float[] cda, float randomValue)
        {
            int lo = 0;
            int hi = cda.Length - 1;
            int index;

            while (lo <= hi)
            {
                // calculate median
                index = lo + ((hi - lo) >> 1);

                if (cda[index] == randomValue)
                {
                    return index;
                }

                if (cda[index] < randomValue)
                {
                    // shrink left
                    lo = index + 1;
                }
                else
                {
                    // shrink right
                    hi = index - 1;
                }
            }

            index = lo;

            return index;
        }

        /// <summary>
        /// Linear search, good/faster for small lists
        /// </summary>
        /// <param name="cdl">Cummulative Distribution List</param>
        /// <param name="randomValue">Uniform random value</param>
        /// <returns>Returns index of an value inside CDA</returns>
        public static int SelectIndexLinearSearch(this List<float> cdl, float randomValue)
        {
            var i = 0;

            // last element, CDL[CDL.Length-1] should always be 1
            while (cdl[i] < randomValue)
            {
                i++;
            }

            return i;
        }

        /// <summary>
        /// Binary search, good/faster for big lists
        /// Code taken out of C# array.cs Binary Search & modified
        /// </summary>
        /// <param name="cdl">Cummulative Distribution List</param>
        /// <param name="randomValue">Uniform random value</param>
        /// <returns>Returns index of an value inside CDL</returns>
        public static int SelectIndexBinarySearch(this List<float> cdl, float randomValue)
        {
            var lo = 0;
            var hi = cdl.Count - 1;
            int index;

            while (lo <= hi)
            {
                // calculate median
                index = lo + ((hi - lo) >> 1);

                if (cdl[index] == randomValue)
                {
                    return index;
                }

                if (cdl[index] < randomValue)
                {
                    // shrink left
                    lo = index + 1;
                }
                else
                {
                    // shrink right
                    hi = index - 1;
                }
            }

            index = lo;

            return index;
        }

        /// <summary>
        /// Returns identity, array[i] = i
        /// </summary>
        /// <param name="length">Length of an array</param>
        /// <returns>Identity array</returns>
        public static float[] IdentityArray(int length)
        {
            var array = new float[length];

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            return array;
        }

        /// <summary>
        /// Gemerates uniform random values for all indexes in array.
        /// </summary>
        /// <param name="array">The array where all values will be randomized.</param>
        /// <param name="r">Random generator</param>
        public static void RandomWeightsArray(ref float[] array, System.Random r)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = (float) r.NextDouble();

                if (array[i] == 0)
                {
                    i--;
                }
            }
        }

        /// <summary>
        /// Creates new array with uniform random variables. 
        /// </summary>
        /// <param name="r">Random generator</param>
        /// <param name="length">Length of new array</param>
        /// <returns>Array with random uniform random variables</returns>
        public static float[] RandomWeightsArray(System.Random r, int length)
        {
            var array = new float[length];

            for (var i = 0; i < length; i++)
            {
                array[i] = (float) r.NextDouble();

                if (array[i] == 0)
                {
                    i--;
                }
            }

            return array;
        }


        /// <summary>
        /// Returns identity, list[i] = i
        /// </summary>
        /// <param name="length">Length of an list</param>
        /// <returns>Identity list</returns>
        public static List<float> IdentityList(int length)
        {
            var list = new List<float>(length);

            for (var i = 0; i < length; i++)
            {
                list.Add(i);
            }

            return list;
        }

        /// <summary>
        /// Gemerates uniform random values for all indexes in list.
        /// </summary>
        /// <param name="list">The list where all values will be randomized.</param>
        /// <param name="r">Random generator</param>
        public static void RandomWeightsList(ref List<float> list, System.Random r)
        {
            for (var i = 0; i < list.Count; i++)
            {
                list[i] = (float) r.NextDouble();

                if (list[i] == 0)
                {
                    i--;
                }
            }
        }
    }
}