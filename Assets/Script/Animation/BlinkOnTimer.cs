using UnityEngine;


namespace Paws { 
    [RequireComponent(typeof(BlinkingSprite))]
    public class BlinkOnTimer : MonoBehaviour
    {
        [SerializeField] private MemoTools.LifetimeTimer _lifetime;
        [SerializeField] private float _duration;
        [Tooltip("Check this if you want to trigger blinking with remaining time instead of elapsed time")]
        [SerializeField] private bool _fromEnd;


        private void Awake()
        {
            _blinkingSprite = GetComponent<BlinkingSprite>();
            _blinkingSprite.enabled = false;
        }

        private void Update()
        {
            if  (ShouldBlink()) _blinkingSprite.enabled = true;
        }

        private bool ShouldBlink()
        {
            return _fromEnd ? (_lifetime.Timer.Remaining < _duration) : (_lifetime.Timer.Elapsed > _duration);
        }

        private BlinkingSprite _blinkingSprite;
    }
}
