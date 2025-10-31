using UnityEngine;

namespace CCRSystemTest.Scripts
{
    namespace Configs
    {
        [CreateAssetMenu(menuName = "Configs/APIConfig", fileName = "APIConfig")]
        public class APIConfig : ScriptableObject
        {
            public int RequestTimout => requestTimout;
            public string APIWeatherGet => apiWeatherGet;
            public string APIDogGet => apiDogGet;
            public string APIFactDogGet => apiFactDogGet;
            [SerializeField] private int requestTimout;
            [SerializeField] private string apiWeatherGet;
            [SerializeField] private string apiDogGet;
            [SerializeField] private string apiFactDogGet;
            
        }
    }
}