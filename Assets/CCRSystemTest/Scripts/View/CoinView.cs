using UnityEngine;
using Zenject;

namespace CCRSystemTest.Scripts
{
    namespace View
    {
        public class CoinView : MonoBehaviour, IPoolable<IMemoryPool>
        {
            public void OnDespawned()
            {
            }

            public void OnSpawned(IMemoryPool pool)
            {
            }
            
            public class Pool : MonoMemoryPool<CoinView>
            {
                protected override void Reinitialize(CoinView item)
                {
                    item.OnSpawned(this);
                }

                protected override void OnDespawned(CoinView item)
                {
                    base.OnDespawned(item);
                    item.OnDespawned();
                }
            }
        }
    }
    
}

