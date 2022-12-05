using UnityEngine;
using Weapons;

namespace Abilitys
{
    public class RatwolfAttack : Ability
    {
        [SerializeField] private SpleshAttack _spleshAttackPrefub;
        [SerializeField] private Transform _attackSpawnpoint;
        protected override void Execute()
        {
            Shot.Summon(_spleshAttackPrefub, _attackSpawnpoint);
        }
    }
}
