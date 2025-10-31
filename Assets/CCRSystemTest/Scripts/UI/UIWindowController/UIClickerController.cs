using CCRSystemTest.Scripts.Controller;
using DG.Tweening;
using Doozy.Runtime.UIManager;
using UnityEngine;

namespace CCRSystemTest.Scripts
{
    namespace UI
    {
        public class UIClickerController
        {
            private readonly IUIService _uiService;
            private readonly ClickerController _clickerController;
            
            private UIClickerWindow _uiClickerWindow;
            
            public UIClickerController(
                IUIService uiService,
                ClickerController clickerController)
            {
                _uiService = uiService;
                _clickerController = clickerController;
            }

            public void Init()
            {
                _uiClickerWindow = _uiService.Get<UIClickerWindow>();
                
                _uiClickerWindow.CoinButton.behaviours.AddBehaviour(UIBehaviour.Name.PointerClick);
                _uiClickerWindow.CoinButton.behaviours.GetBehaviour(UIBehaviour.Name.PointerClick).Event.AddListener(Click);

                _clickerController.ClickEvent += _uiClickerWindow.CoinButton.ClickWithAnimation;
                _clickerController.ChangeCoinScoreEvent += HandlerChangeCoinScoreEvent;
                _clickerController.ChangeEnergyScoreEvent += HandlerChangeEnergyScoreEvent;
                _clickerController.ChangeMaxEnergyScoreEvent += HandlerChangeMaxEnergyScoreEvent;
                
                _clickerController.Init();
            }

            public void StartClicker()
            {
                _clickerController.Start();
            }

            public void StopClicker()
            {
                _clickerController.Stop();
            }
            
            private void Click()
            {
               var coin = _clickerController.SpawnCoin();
               
               if (coin == null)
               {
                   return;
               }
               
               Transform transformCoin;
               (transformCoin = coin.transform).SetParent(_uiClickerWindow.transform);
               
               transformCoin.localPosition = Vector3.zero;
               transformCoin.localRotation = Quaternion.identity;
               transformCoin.localScale = Vector3.one;
               transformCoin.DOMoveY(transformCoin.position.y + 10, 0.5f);
            }
            
            private void HandlerChangeCoinScoreEvent(int currentCoinScore)
            {
                _uiClickerWindow.CurrentScoreTMPText.text = currentCoinScore.ToString();
            }
            
            private void HandlerChangeEnergyScoreEvent(int currentEnergyScore)
            {
                _uiClickerWindow.CurrentEnergyTMPText.text = currentEnergyScore.ToString();
            }
            
            private void HandlerChangeMaxEnergyScoreEvent(int currentMaxEnergyScore)
            {
                _uiClickerWindow.MaxEnergyTMPText.text = currentMaxEnergyScore.ToString();
            }
        }
    }
}