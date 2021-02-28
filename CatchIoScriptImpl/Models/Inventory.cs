using System;
using System.Collections.Generic;
using System.Text;

namespace CatchIoScriptImpl.Models
{
    class Inventory
    {
        private Dictionary<int, Item> _storeItemDictionary;
        private int _maxInventorySize;

        public Inventory(int maxInventorySize = 4)
        {
            //Init inventoryDictionary.
            _storeItemDictionary = new Dictionary<int, Item>();
            // Set inventory maxSize.
            SetInventoryMaxSize(maxInventorySize);
        }

        private void SetInventoryMaxSize(int maxSize)
        {
            // If maxSize less than 1
            // Set maxSize to 1.
            if (maxSize < 1)
            {
                maxSize = 1;
                Console.WriteLine("Max inventory size cannot be lower than 1");
            }

            // If current inventory size greater than maxSize
            // Set item index order zero to maxSize.
            if (_storeItemDictionary.Count > maxSize)
            {
                Item[] storedItems = new Item[_storeItemDictionary.Count];
                for (int i = 0; i < _storeItemDictionary.Count; i++)
                {
                    storedItems[i] = _storeItemDictionary[i];
                }

                _storeItemDictionary.Clear();

                for (int i = 0; i < storedItems.Length; i++)
                {
                    _storeItemDictionary.Add(i, storedItems[i]);
                }

                maxSize = _storeItemDictionary.Count;
            }

            _maxInventorySize = maxSize;
        }

        public void AddItem(Item newItem)
        {
            if (!IsFull())
            {
                _storeItemDictionary.Add(_storeItemDictionary.Count, newItem);
            }
        }

        public void RemoveItem(int index)
        {
            // If inventory is empty and inventory doesn't contain index.
            if (!IsEmpty() && _storeItemDictionary.ContainsKey(index))
            {
                _storeItemDictionary.Remove(index);
            }
        }

        public Item GetItem(int index)
        {
            if (!IsEmpty() && _storeItemDictionary.ContainsKey(index))
            {
                return _storeItemDictionary[index];
            }

            return null;
        }

        public bool IsFull()
        {
            return _storeItemDictionary.Count == _maxInventorySize - 1;
        }

        public bool IsEmpty()
        {
            return _storeItemDictionary.Count == 0;
        }

        public void Draw()
        {
            for (int i = 0; i < _storeItemDictionary.Count; i++)
            {
                Console.Write(_storeItemDictionary[i].ToString() + '\t');
            }
            Console.WriteLine();
        }
    }
}
