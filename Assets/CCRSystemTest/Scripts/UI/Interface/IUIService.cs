using System;
using UnityEngine;

namespace CCRSystemTest.Scripts
{
    namespace UI
    {
        public interface IUIService
        {
            T Show<T> () where T : UIWindow;
            void Hide<T>() where T : UIWindow;
            T Get<T>() where T : UIWindow;
            void InitWindows(Camera camera);
            void LoadWindows();
        }
    }
    
}