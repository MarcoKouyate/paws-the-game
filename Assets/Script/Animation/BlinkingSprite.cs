using UnityEngine;


namespace Paws { 

    [RequireComponent(typeof(SpriteRenderer))]
    public class BlinkingSprite : MonoBehaviour
    {
        [SerializeField] private float _interval;
        [SerializeField] private Color _color;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _timer = new MemoTools.Timer(_interval, true);
            _baseColor = _spriteRenderer.color;
        }

        public void Update()
        {
            if (_timer.OnTimeEnd)
            {
                SwitchColor();
            }
        }

        private void SwitchColor()
        {
            _highlight = !_highlight;
            _spriteRenderer.color = _highlight ? _color : _baseColor;
        }

        private void OnDisable()
        {
            _spriteRenderer.color = _baseColor;
        }

        private Color _baseColor;
        private bool _highlight;
        private MemoTools.Timer _timer;
        private SpriteRenderer _spriteRenderer;
    }
}
