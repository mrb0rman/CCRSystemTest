using UnityEngine;

namespace CCRSystemTest.Scripts
{
    namespace View
    {
        public class CameraView : MonoBehaviour
        {
            public Camera Camera => camera;
            [SerializeField] private Camera camera;
        }
    }
    
}

