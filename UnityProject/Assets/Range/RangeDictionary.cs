using System.Collections.Generic;
using System;
using UnityEngine;

namespace Range
{
    [Serializable]
    struct RangeSpriteDictionarityItem<T>
    {
        public Range<int> Key;
        public T Sprite;
    }

    [Serializable]
    struct RangeSpriteDictionarity
    {
        private List<RangeSpriteDictionarityItem<Sprite>> _items;

        public RangeSpriteDictionarity(IEnumerable<RangeSpriteDictionarityItem<Sprite>> container)
        {
            _items = new();
            _items.AddRange(container);
        }

        public Sprite this[int index]
        {
            get
            {
                foreach (RangeSpriteDictionarityItem<Sprite> item in _items)
                {
                    if (item.Key.Include(index))
                    {
                        return item.Sprite;
                    }
                }
                throw new ArgumentException("This dictionary don't include this value");
            }
        }
    }
}
