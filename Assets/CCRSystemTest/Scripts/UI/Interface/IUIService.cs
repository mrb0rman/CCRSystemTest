using System;
using UnityEngine;

namespace CCRSystemTest.Scripts
{
    namespace UI
    {
        public interface IUIService
        {
            T Show<T> (Action onEnd = null) where T : UIWindow;
            void Hide<T>(Action onEnd = null) where T : UIWindow;
            T Get<T>() where T : UIWindow;
            void InitWindows(Camera camera);
            void LoadWindows();
        }
    }
    
}