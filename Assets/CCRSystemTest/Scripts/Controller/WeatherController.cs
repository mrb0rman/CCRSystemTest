using System;
using System.Threading;
using CCRSystemTest.Scripts.Configs;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace CCRSystemTest.Scripts
{
    namespace Controller
    {
        public class WeatherController
        {
            private readonly APIConfig _apiConfig;
            public Action<Texture2D, string> GetRecordWeatherEvent;
            
            private readonly CompositeDisposable _disposables = new();
            
            private CancellationTokenSource _cancellationToken;
            
            public WeatherController(APIConfig apiConfig)
            {
                _apiConfig = apiConfig;
            }

            public void StartRequest()
            {
                _cancellationToken = new CancellationTokenSource();
                
                Observable.Interval(System.TimeSpan.FromSeconds(5))
                    .StartWith(0)
                    .Subscribe(_ => GetWeatherAsync(_cancellationToken.Token).Forget())
                    .AddTo(_disposables);
            }

            public void StopRequest()
            {
                _disposables.Clear();
                
                _cancellationToken?.Cancel();
                _cancellationToken?.Dispose();
                _cancellationToken = null;
            }

            private async UniTaskVoid GetWeatherAsync(CancellationToken token)
            {
                using var request = UnityWebRequest.Get(_apiConfig.APIWeatherGet);
                
                try
                {
                    await request.SendWebRequest().ToUniTask(cancellationToken: token);
                    
                    if (request.result != UnityWebRequest.Result.Success)
                        throw new Exception($"HTTP Error: {request.error}");
                
                    var root = JsonUtility.FromJson<WeatherRoot>(request.downloadHandler.text);
                    var periodToday = root.properties.periods[0];
                    
                    using var requestImage = UnityWebRequestTexture.GetTexture(periodToday.icon);
                    
                    await requestImage.SendWebRequest().ToUniTask(cancellationToken: token);
                    
                    if (requestImage.result != UnityWebRequest.Result.Success)
                        throw new Exception($"HTTP Error: {requestImage.error}");
                    
                    var texture = DownloadHandlerTexture.GetContent(requestImage);
                    
                    GetRecordWeatherEvent?.Invoke(texture, $"{periodToday.temperature}{periodToday.temperatureUnit}");
                }
                catch (OperationCanceledException)
                {
                    Debug.LogWarning($"Request cancelled");
                }
                catch (Exception exception)
                {
                    Debug.LogError($"Error: {exception.Message}");
                }
            }
        }
        
        [Serializable]
        public class WeatherRoot
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
            public int temperature;
            public string temperatureUnit;
            public string icon;
        }
    }
}
