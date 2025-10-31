using UnityEngine;

namespace CCRSystemTest.Scripts
{
    namespace Configs
    {
        [CreateAssetMenu(menuName = "Configs/ClickerConfig", fileName = "ClickerConfig")]
        public class ClickerConfig : ScriptableObject
        {
            public AudioClip AudioClipClick => audioClipClick;
            public int ValueClick => valueClick;
            
            public int TimeClickPeriod => timeClickPeriod;
            
            public int CostEnergyPerClick => costEnergyPerClick;
            public int MaxEnergy => maxEnergy;
            public int RecoveryEnergyPerTime => recoveryEnergyPerTime;
            public int RecoveryTimeEnergyPeriod => recoveryTimeEnergyPeriod;

            [SerializeField] private AudioClip audioClipClick;
            [SerializeField] private int valueClick;
            
            [Header("Autoclicker parameters")]
            [SerializeField] private int timeClickPeriod;
            
            [Header("Energy parameters")]
            [SerializeField] private int costEnergyPerClick;
            [SerializeField] private int maxEnergy;
            [SerializeField] private int recoveryEnergyPerTime;
            [SerializeField] private int recoveryTimeEnergyPeriod;
        }
    }
}