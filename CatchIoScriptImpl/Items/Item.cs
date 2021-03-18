// Copyright (c) Team STEP.  All Rights Reserved.

namespace CatchIoScriptImpl.Items
{
    public abstract class Item
    {
        public virtual bool IsStored => _isStored;

        private bool _isStored = false;

        public virtual void OnPickup()
        {
            if (!_isStored)
                _isStored = true;
        }

        public virtual void OnDiscard()
        {
            if (_isStored)
                _isStored = false;
        }
    }

}
