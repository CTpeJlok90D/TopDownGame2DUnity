using UnityEngine.Events;

namespace Weapons
{
    public interface IReloadeble
    {
        public int AmmoCount {get;}
        public UnityEvent<int> AmmoCountChanged {get;}
        public void Reload();
    }
}
