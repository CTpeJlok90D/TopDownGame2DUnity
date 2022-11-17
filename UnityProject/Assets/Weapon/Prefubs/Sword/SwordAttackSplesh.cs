using System;
using System.Collections.Generic;

namespace Weapons
{
    public class SwordAttackSplesh : Shot
    {
        private static List<SwordAttackSplesh> _instanses = new();

        public override Type CurrentShotType => typeof(SwordAttackSplesh);

        public override Shot Init(OwnerInfo _info)
        {
            return this;
        }
    }
}
