using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CCRSystemTest.Scripts
{
    namespace UI
    {
        public class UIWeatherWindow : UIWindow
        {
            public TMP_Text RecordWeatherTMPText => recordWeatherTMPText;
            public Image WeatherIconImage => weatherIconImage;
            [SerializeField] private TMP_Text recordWeatherTMPText;
            [SerializeField] private Image weatherIconImage;
        }
    }
}