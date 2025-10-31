using Doozy.Runtime.UIManager.Components;
using TMPro;
using UnityEngine;

namespace CCRSystemTest.Scripts
{
    namespace UI
    {
        public class FactPanelView : MonoBehaviour
        {
            public UIButton OkButton => okButton;
            public TMP_Text NameTMPText => nameTMPText;
            public TMP_Text DescriptionTMPText => descriptionTMPText;
            [SerializeField] private UIButton okButton;
            [SerializeField] private TMP_Text nameTMPText;
            [SerializeField] private TMP_Text descriptionTMPText;
        }
    }
}

