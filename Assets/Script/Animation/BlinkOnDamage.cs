using UnityEngine;

namespace Paws {
    [RequireComponent(typeof(BlinkingSprite))]
    public class BlinkOnDamage : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private Health _health;

        private void Awake()
        {
            _health.OnDamage += OnDamage;
            _timer = new MemoTools.Timer(_duration, false);
            _blinking = GetComponent<BlinkingSprite>();
            _blinking.enabled = false;
        }

        public void Update()
        {
            if(_timer.OnTimeEnd)
            {
                _blinking.enabled = false;
            }
        }

        private void OnDamage(object sender, System.EventArgs e)
        {
            _timer.Reset();
            _blinking.enabled = true;
        }

        private MemoTools.Timer _timer;
        private BlinkingSprite _blinking;
    }
}
