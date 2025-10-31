using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace CCRSystemTest.Scripts
{
    namespace UI
    {
        public class UIWeatherWindow : UIWindow
        {
            private void Start()
            {
                StartCoroutine(LoadFromServer());
            }
            
            IEnumerator LoadFromServer()
            {
                using var request = UnityWebRequest.Get("https://api.weather.gov/gridpoints/TOP/32,81/forecast");
                
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    var data = request.downloadHandler.text;
                    
                    var root = JsonUtility.FromJson<Root>(data);
                    var periods = root?.properties?.periods;
                    
                    if (periods == null || periods.Length == 0)
                        throw new Exception("No periods in response");
                    
                    Debug.Log(root.properties.periods[0].name);
                    Debug.Log(root.properties.periods[0].temperature);
                    Debug.Log(root.properties.periods[0].temperatureUnit);
                    Debug.Log(root.properties.periods[0].icon);
                }
            }
        }
        
        [Serializable]
        public class Root
        {
            public Properties properties;
        }

        [Serializable]
        public class Properties
        {
            public Period[] periods;
        }
        
        
        [Serializable]
        public class Period
        {
            public string name;
            public int temperature;
            public string temperatureUnit;
            public string icon;
        }
    }
}