using UnityEngine;

namespace CCRSystemTest.Scripts
{
    namespace Configs
    {
        [CreateAssetMenu(menuName = "Configs/APIWeatherConfig", fileName = "APIWeatherConfig")]
        public class APIWeatherConfig : ScriptableObject
        {
            [SerializeField] private Vector2 coordinates;

            public string GetApi()
            {
                return $"https://api.weather.gov/gridpoints/TOP/{coordinates.x},{coordinates.y}/forecast";
            }
        }
    }
}