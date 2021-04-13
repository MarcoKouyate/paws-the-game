using UnityEngine;


namespace Paws { 
    [RequireComponent(typeof(SpriteRenderer))]
    public class ToggleSprite : MonoBehaviour
    {
        [SerializeField] private Sprite _OnSprite;
        [SerializeField] private Sprite _OffSprite;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            Toggle(false);
        }


        public void Toggle(bool active)
        {
            _spriteRenderer.sprite = active ? _OnSprite : _OffSprite;
        }

        private SpriteRenderer _spriteRenderer;
    }
}
