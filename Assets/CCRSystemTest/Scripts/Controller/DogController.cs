using System;
using System.Threading;
using CCRSystemTest.Scripts.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace CCRSystemTest.Scripts
{
    namespace Controller
    {
        public class DogController
        {
            public Action ExceptionEvent;
            public Action<DogData[]> GetDogDataEvent;
            public Action<DogData> GetFactDogEvent;
            
            private readonly APIConfig _apiConfig;
            
            private CancellationTokenSource _cancellationTokenDogs;
            private CancellationTokenSource _cancellationTokenFacts;
            
            public DogController(
                APIConfig apiConfig)
            {
                _apiConfig = apiConfig;
            }
            
            public void SendRequestDog()
            {
                _cancellationTokenDogs = new CancellationTokenSource();

                GetListDogAsync(_cancellationTokenDogs.Token).Forget();
            }

            public void CancelRequestDog()
            {
                _cancellationTokenDogs?.Cancel();
                _cancellationTokenDogs?.Dispose();
                _cancellationTokenDogs = null;
                
                _cancellationTokenFacts?.Cancel();
                _cancellationTokenFacts?.Dispose();
                _cancellationTokenFacts = null;
            }

            public void SendRequestFact(string id)
            {
                _cancellationTokenFacts?.Cancel();
                _cancellationTokenFacts?.Dispose();
                _cancellationTokenFacts = null;
                
                _cancellationTokenFacts = new CancellationTokenSource();

                GetFactDogAsync(_cancellationTokenFacts.Token, id).Forget();
            }
            
            private async UniTaskVoid GetListDogAsync(CancellationToken token)
            {
                using var request = UnityWebRequest.Get(_apiConfig.APIDogGet);
                request.timeout = _apiConfig.RequestTimout;

                try
                {
                    await request.SendWebRequest().ToUniTask(cancellationToken: token);

                    if (request.result != UnityWebRequest.Result.Success)
                        throw new Exception($"HTTP Error: {request.error}");

                    GetDogDataEvent?.Invoke(JsonUtility.FromJson<DogRoot>(request.downloadHandler.text).data);
                }
                catch (OperationCanceledException)
                {
                    Debug.LogWarning($"Request cancelled");
                }
                catch (Exception exception)
                {
                    Debug.Log(request.responseCode);
                    Debug.LogError($"Error: {exception.Message}");
                    ExceptionEvent?.Invoke();
                }
            }
            
            private async UniTaskVoid GetFactDogAsync(CancellationToken token, string id)
            {
                using var request = UnityWebRequest.Get(_apiConfig.APIFactDogGet + id);
                request.timeout = 60;
                try
                {
                    await request.SendWebRequest().ToUniTask(cancellationToken: token);
                    
                    if (request.result != UnityWebRequest.Result.Success)
                        throw new Exception($"HTTP Error: {request.error}");
                    
                    GetFactDogEvent?.Invoke(JsonUtility.FromJson<DogFactRoot>(request.downloadHandler.text).data);
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
        public class DogRoot
        {
            public DogData[] data;
        }
        
        [Serializable]
        public class DogFactRoot
        {
            public DogData data;
        }

        [Serializable]
        public class DogData
        {
            public string id;
            public Attributes attributes;
        }
        
        [Serializable]
        public class Attributes
        {
            public string name;
            public string description;
        }
    }
}