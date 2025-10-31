using UnityEngine;
using Zenject;

namespace CCRSystemTest.Scripts
{
    namespace View
    {
        public class SoundClickView : MonoBehaviour, IPoolable<SoundClickProtocol, IMemoryPool>
        {
            [SerializeField] private AudioSource audioSource;
            public void OnDespawned()
            {
            }

            public void OnSpawned(SoundClickProtocol protocol, IMemoryPool pool)
            {
                audioSource.clip = protocol.AudioClip;
            }
            
            public class Pool : MonoMemoryPool<SoundClickProtocol, SoundClickView>
            {
                protected override void Reinitialize(SoundClickProtocol protocol, SoundClickView item)
                {
                    item.OnSpawned(protocol, this);
                }

                protected override void OnDespawned(SoundClickView item)
                {
                    base.OnDespawned(item);
                    item.OnDespawned();
                }
            }
        }

        public class SoundClickProtocol
        {
            public AudioClip AudioClip;
            
            public SoundClickProtocol(AudioClip audioClip)
            {
                AudioClip = audioClip;
            }
        }
    }
}

