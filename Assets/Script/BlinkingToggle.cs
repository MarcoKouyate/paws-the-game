using UnityEngine;


namespace Paws { 
    public class BlinkingToggle : MemoTools.Blinker
    {
        [SerializeField] private GameObject _objectToToggle;

        [Tooltip("tell if you want active as default state")]
        [SerializeField] private bool _activeIsNormal = true;

        protected override void BlinkOff()
        {
            _objectToToggle.SetActive(_activeIsNormal);
        }

        protected override void BlinkOn()
        {
            _objectToToggle.SetActive(!_activeIsNormal);
        }
    }
}
