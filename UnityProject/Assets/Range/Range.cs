using System;

namespace Range
{
    [Serializable]
    public struct Range<T> where T : IComparable
    {
        public T Max;
        public T Min;

        public Range(T min, T max)
        {
            Max = max;
            Min = min;
        }

        public bool Include(T value) => value.CompareTo(Max) <= 0 && value.CompareTo(Min) >= 0;
    }
}