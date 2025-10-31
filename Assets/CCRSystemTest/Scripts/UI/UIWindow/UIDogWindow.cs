using UnityEngine;
using UnityEngine.UI;

namespace CCRSystemTest.Scripts
{
    namespace UI
    {
        public class UIDogWindow : UIWindow
        {
            public FactPanelView FactPanelView => factPanelView;
            public Transform DogButtonPanelTransform => dogButtonPanelTransform;
            public Image LoadingImage => loadingImage;
            [SerializeField] private FactPanelView factPanelView;
            [SerializeField] private Transform dogButtonPanelTransform;
            [SerializeField] private Image loadingImage;
            
        }
    }
}