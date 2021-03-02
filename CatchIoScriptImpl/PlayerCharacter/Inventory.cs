using System;
using System.Collections.Generic;
using System.Text;
using CatchIoScriptImpl.Items;

namespace CatchIoScriptImpl.PlayerCharacter
{
    class Inventory
    {
        // note: the item slots are zero-indexed, but the UI will label them from slot 1
        private readonly Dictionary<int, Item> _storeItemDictionary;
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
                Item[] storedItems = ToArray();

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

        public void RemoveItem(int slotNo)
        {
            if (GetItem(slotNo) != null)
            {
                _storeItemDictionary[slotNo] = null;
            }
        }

        public Item GetItem(int slotNo)
        {
            // only if the inventory is not empty and contains an item
            if (!IsEmpty() && _storeItemDictionary.ContainsKey(slotNo) && _storeItemDictionary[slotNo] != null)
            {
                return _storeItemDictionary[slotNo];
            }

            return null;
        }

        public bool IsFull()
        {
            // note: we can have a null value for an existing key, so using count might not be effective
            return _storeItemDictionary.Count == _maxInventorySize - 1;
        }

        public bool IsEmpty()
        {
            return _storeItemDictionary.Count == 0;
        }

        public Item[] ToArray()
        {
            Item[] storedItems = new Item[_storeItemDictionary.Count];
            for (int i = 0; i < _storeItemDictionary.Count; i++)
            {
                storedItems[i] = _storeItemDictionary[i];
            }

            return storedItems;
        }

        public void Draw()
        {
            /*
            for (int i = 0; i < _storeItemDictionary.Count; i++)
            {
                Console.Write(_storeItemDictionary[i].ToString() + '\t');
            }
            Console.WriteLine();
            */
            Item[] invData = ToArray();
            for (int i = 0; i < invData.Length; i++)
            {
                Item currentItem = invData[i];
                if (currentItem == null)
                {
                    Console.WriteLine($"No item in slot {i + 1}");
                }
                else
                {
                    Console.WriteLine($"{invData[i]} in slot {i + 1}");
                }
            }
        }
    }
}
