using System;
using CCRSystemTest.Scripts.Configs;
using CCRSystemTest.Scripts.View;
using DG.Tweening;

namespace CCRSystemTest.Scripts
{
    namespace Controller
    {
        public class ClickerController
        {
            public Action ClickEvent;
            public Action<int> ChangeCoinScoreEvent;
            public Action<int> ChangeEnergyScoreEvent;
            public Action<int> ChangeMaxEnergyScoreEvent;
            
            private readonly ClickerConfig _clickerConfig;
            private readonly CoinView.Pool _coinPool;
            private readonly SoundClickView.Pool _soundClickPool;

            private Tween _recoveryEnergyTween;
            private Tween _autoClickTween;
            
            private int _currentCoinScore;
            private int _currentEnergyScore;

            private bool _isStop = true;
            
            public ClickerController(
                ClickerConfig clickerConfig,
                CoinView.Pool coinPool,
                SoundClickView.Pool soundClickPool)
            {
                _clickerConfig = clickerConfig;
                _coinPool = coinPool;
                _soundClickPool = soundClickPool;
            }

            public void Init()
            {
                _currentEnergyScore = _clickerConfig.MaxEnergy;

                ChangeCoinScoreEvent?.Invoke(_currentCoinScore);
                ChangeEnergyScoreEvent?.Invoke(_currentEnergyScore);
                ChangeMaxEnergyScoreEvent?.Invoke(_clickerConfig.MaxEnergy);
                
                
            }

            public void Start()
            {
                StartAutoClick();
            }

            public void Stop()
            {
                StopAutoClicker();
            }
            
            public CoinView SpawnCoin()
            {
                if (_currentEnergyScore <= 0)
                {
                    return null;
                }
                _currentCoinScore += _clickerConfig.ValueClick;
                _currentEnergyScore -= _clickerConfig.CostEnergyPerClick;
                
                ChangeCoinScoreEvent?.Invoke(_currentCoinScore);
                ChangeEnergyScoreEvent?.Invoke(_currentEnergyScore);
                
                var currentCoinView = _coinPool.Spawn();
                var soundClickView = _soundClickPool.Spawn(new SoundClickProtocol(_clickerConfig.AudioClipClick));
                
                DOVirtual.DelayedCall(0.5f, () =>
                {
                    _coinPool.Despawn(currentCoinView);
                    _soundClickPool.Despawn(soundClickView);
                });

                return currentCoinView;
            }

            private void StartAutoClick()
            {
                _recoveryEnergyTween = DOVirtual.DelayedCall(_clickerConfig.RecoveryTimeEnergyPeriod, () =>
                {
                    _currentEnergyScore += _clickerConfig.RecoveryEnergyPerTime;
                    
                    if (_currentEnergyScore > _clickerConfig.MaxEnergy)
                    {
                        _currentEnergyScore = _clickerConfig.MaxEnergy;
                    }
                    ChangeEnergyScoreEvent?.Invoke(_currentEnergyScore);
                    
                }).SetLoops(-1);
                
                _autoClickTween = DOVirtual.DelayedCall(_clickerConfig.TimeClickPeriod, () =>
                {
                    ClickEvent?.Invoke();
                }).SetLoops(-1);
            }

            private void StopAutoClicker()
            {
                _recoveryEnergyTween.Kill();
                _recoveryEnergyTween = null;
                
                _autoClickTween.Kill();
                _autoClickTween = null;
            }
        }
    }
}

