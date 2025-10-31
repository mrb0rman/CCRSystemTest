using System;
using DG.Tweening;
using Doozy.Runtime.UIManager;
using Doozy.Runtime.UIManager.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CCRSystemTest.Scripts
{
    namespace View
    {
        public class DogButtonView : MonoBehaviour, IPoolable<DogButtonProtocol, IMemoryPool>
        {
            public Action<DogButtonView> SendRequestFactEvent;
            public Image LoadingImage => loadingImage;
            
            public string ID { get; private set; }
            [SerializeField] private UIButton uiButton;
            [SerializeField] private TMP_Text nameTMPText;
            [SerializeField] private TMP_Text numberTMPText;
            [SerializeField] private Image loadingImage;

            private Tween _loadingTween;
            public void OnDespawned()
            {
                StopAnimationLoading();
                
                numberTMPText.text = string.Empty;
                ID = string.Empty;
                nameTMPText.text = string.Empty;
                
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                transform.localScale = Vector3.one;
                
                uiButton.behaviours.GetBehaviour(UIBehaviour.Name.PointerClick).Event.RemoveListener(SendRequestFact);
                uiButton.behaviours.RemoveBehaviour(UIBehaviour.Name.PointerClick);
                
            }

            public void OnSpawned(DogButtonProtocol protocol, IMemoryPool pool)
            {
                loadingImage.enabled = false;
                
                numberTMPText.text = protocol.Number;
                ID = protocol.ID;
                nameTMPText.text = protocol.Name;

                uiButton.behaviours.AddBehaviour(UIBehaviour.Name.PointerClick);
                uiButton.behaviours.GetBehaviour(UIBehaviour.Name.PointerClick).Event.AddListener(SendRequestFact);
            }

            public void  StartAnimationLoading()
            {
                loadingImage.enabled = true;
                _loadingTween = loadingImage.transform
                    .DORotate(new Vector3(0, 0, -360f), 2f, RotateMode.FastBeyond360)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1)
                    .OnKill(() =>
                    {
                        loadingImage.transform.localRotation = Quaternion.identity;
                    });
            }
            
            public void StopAnimationLoading()
            {
                loadingImage.enabled = false; 
                
                _loadingTween?.Kill();
                _loadingTween = null;
            }
            
            private void SendRequestFact()
            {
                SendRequestFactEvent?.Invoke(this);
            }
            
            
            
            public class Pool : MonoMemoryPool<DogButtonProtocol, DogButtonView>
            {
                protected override void Reinitialize(DogButtonProtocol protocol, DogButtonView item)
                {
                    item.OnSpawned(protocol, this);
                }

                protected override void OnDespawned(DogButtonView item)
                {
                    base.OnDespawned(item);
                    item.OnDespawned();
                }
            }
        }

        public class DogButtonProtocol
        {
            public string Number;
            public string ID;
            public string Name;
            public DogButtonProtocol(
                string number,
                string id, 
                string name)
            {
                Number = number;
                ID = id;
                Name = name;
            }
        }
    }
}