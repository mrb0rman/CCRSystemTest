using System.Collections.Generic;
using System.Linq;
using CCRSystemTest.Scripts.Controller;
using CCRSystemTest.Scripts.View;
using DG.Tweening;
using Doozy.Runtime.UIManager;
using UnityEngine;

namespace CCRSystemTest.Scripts
{
    namespace UI
    {
        public class UIDogController
        {
            private const int AMOUNT_DOG_DATA = 10;
            private readonly IUIService _uiService;
            private readonly DogController _dogController;
            private readonly DogButtonView.Pool _dogButtonPool;

            private Tween _loadingTween;
            private List<DogButtonView> _listDogButton = new(10);
            private UIDogWindow _uiDogWindow;
            private DogButtonView _currentClickDogButtonView;
            
            public UIDogController(
                IUIService uiService,
                DogController dogController,
                DogButtonView.Pool dogButtonPool)
            {
                _uiService = uiService;
                _dogController = dogController;
                _dogButtonPool = dogButtonPool;
            }
            
            public void Init()
            {
                _uiDogWindow = _uiService.Get<UIDogWindow>();

                _dogController.ExceptionEvent += StopAnimationLoading;
                _dogController.GetDogDataEvent += HandlerGetDogDataEvent;
                _dogController.GetFactDogEvent += HandlerGetFactDogEvent;
            }
            
            public void StartDogRequest()
            {
                _uiDogWindow.FactPanelView.gameObject.SetActive(false);
                StartAnimationLoading();
                _dogController.SendRequestDog();
            }

            public void StopDogRequest()
            {
                _uiDogWindow.FactPanelView.gameObject.SetActive(false);
                StopAnimationLoading();
                ClearDogPanel();
                
                _dogController.CancelRequestDog();
            }
            
            private void HandlerGetDogDataEvent(DogData[] dogData)
            {
                StopAnimationLoading();
                
                var rnd = new System.Random();
                dogData = dogData.OrderBy(x => rnd.Next()).ToArray();

                var newDogData = dogData.Take(AMOUNT_DOG_DATA).ToArray();

                foreach (var dog in newDogData)
                {
                    var dogButton =
                        _dogButtonPool.Spawn(new DogButtonProtocol((_listDogButton.Count + 1).ToString(), dog.id, dog.attributes.name));
                    Transform dogButtonTransform;
                    (dogButtonTransform = dogButton.transform).SetParent(_uiDogWindow.DogButtonPanelTransform);
                    
                    dogButtonTransform.localPosition = Vector3.zero;
                    dogButtonTransform.localRotation = Quaternion.identity;
                    dogButtonTransform.localScale = Vector3.one;

                    dogButton.SendRequestFactEvent += HandlerSendRequestFactEvent;
                    _listDogButton.Add(dogButton);
                }
            }
            
            private void HandlerGetFactDogEvent(DogData dogData)
            {
                _uiDogWindow.FactPanelView.NameTMPText.text = dogData.attributes.name;
                _uiDogWindow.FactPanelView.DescriptionTMPText.text = dogData.attributes.description;
                
                _uiDogWindow.FactPanelView.OkButton.AddBehaviour(UIBehaviour.Name.PointerClick);
                _uiDogWindow.FactPanelView.OkButton.GetBehaviour(UIBehaviour.Name.PointerClick).Event.AddListener(HideFactPanel);
                
                _currentClickDogButtonView.StopAnimationLoading();
                _uiDogWindow.FactPanelView.gameObject.SetActive(true);
            }
            
            private void ClearDogPanel()
            {
                foreach (var dogButtonView in _listDogButton)
                {
                    dogButtonView.SendRequestFactEvent -= HandlerSendRequestFactEvent;
                    _dogButtonPool.Despawn(dogButtonView);
                }
                
                _listDogButton.Clear();
            }
            
            private void HandlerSendRequestFactEvent(DogButtonView dogButtonView)
            {
                HideFactPanel();
                
                _currentClickDogButtonView?.StopAnimationLoading();
                _currentClickDogButtonView = dogButtonView;
                _currentClickDogButtonView.StartAnimationLoading();
                
                _dogController.SendRequestFact(dogButtonView.ID);
            }

            private void  StartAnimationLoading()
            {
                _uiDogWindow.LoadingImage.enabled = true;
                _loadingTween = _uiDogWindow.LoadingImage.transform
                    .DORotate(new Vector3(0, 0, -360f), 2f, RotateMode.FastBeyond360)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1)
                    .OnKill(() =>
                    {
                        _uiDogWindow.LoadingImage.transform.localRotation = Quaternion.identity;
                    });
            }

            private void StopAnimationLoading()
            {
                _uiDogWindow.LoadingImage.enabled = false;
                
                _loadingTween?.Kill();
                _loadingTween = null;
            }

            private void HideFactPanel()
            {
                _uiDogWindow.FactPanelView.OkButton.GetBehaviour(UIBehaviour.Name.PointerClick)?.Event.RemoveListener(HideFactPanel);
                _uiDogWindow.FactPanelView.OkButton.RemoveBehaviour(UIBehaviour.Name.PointerClick);
                
                _uiDogWindow.FactPanelView.gameObject.SetActive(false);
            }
        }
    }
}