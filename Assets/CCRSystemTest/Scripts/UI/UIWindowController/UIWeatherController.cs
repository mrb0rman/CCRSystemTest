using CCRSystemTest.Scripts.Controller;
using UnityEngine;

namespace CCRSystemTest.Scripts
{
    namespace UI
    {
        public class UIWeatherController
        {
            private readonly IUIService _uiService;
            private readonly WeatherController _weatherController;

            private UIWeatherWindow _uiWeatherWindow;

            public UIWeatherController(
                IUIService uiService,
                WeatherController weatherController)
            {
                _uiService = uiService;
                _weatherController = weatherController;
            }

            public void Init()
            {
                _uiWeatherWindow = _uiService.Get<UIWeatherWindow>();
                _uiWeatherWindow.WeatherIconImage.enabled = false;
                
                _weatherController.GetRecordWeatherEvent += HandlerGetRecordWeatherEvent;
            }
            
            public void StartWeatherRequest()
            {
                _weatherController.StartRequest();
            }

            public void StopWeatherRequest()
            {
                _weatherController.StopRequest();
            }
            
            private void HandlerGetRecordWeatherEvent(Texture2D texture2D, string recordWeather)
            {
                _uiWeatherWindow.WeatherIconImage.sprite = Sprite.Create(
                    texture2D,
                    new Rect(0, 0, texture2D.width, texture2D.height),
                    new Vector2(0.5f, 0.5f),
                    100f
                );
                _uiWeatherWindow.WeatherIconImage.enabled = true;
                _uiWeatherWindow.RecordWeatherTMPText.text = $"Сегодня - {recordWeather}";
            }
        }
    }
}