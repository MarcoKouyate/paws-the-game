using UnityEngine;


namespace Paws { 

    [RequireComponent(typeof(SpriteRenderer))]
    public class BlinkingSprite : MemoTools.Blinker
    {

        [SerializeField] private Color _color;

        protected override void DoAwake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _baseColor = _spriteRenderer.color;
        }

        protected override void BlinkOff()
        {
            _spriteRenderer.color = _baseColor;
        }

        protected override void BlinkOn()
        {
            _spriteRenderer.color = _color;
        }

        private void OnDisable()
        {
            BlinkOff();
        }

        private Color _baseColor;
        private SpriteRenderer _spriteRenderer;
    }
}
