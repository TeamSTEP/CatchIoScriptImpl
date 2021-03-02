using System;
using System.Collections.Generic;
using System.Text;

namespace CatchIoScriptImpl.Items
{
    class Stone : OffensiveThrowableItem
    {
        private readonly float _damageVal = 13;
        public override float DamageVal { get { return _damageVal; } }

        public override void Throw()
        {
            Console.WriteLine("Throwing stone");
        }
    }
}
