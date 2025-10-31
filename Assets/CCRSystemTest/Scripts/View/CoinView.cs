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
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                transform.localScale = Vector3.one;
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

