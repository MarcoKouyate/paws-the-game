using UnityEngine;


namespace Paws { 

    [RequireComponent(typeof(ToggleSprite))]
    public class ToggleDoorSprite : MonoBehaviour
    {
        [SerializeField] private Door _door;

        private void Awake()
        {
            _sprite = GetComponent<ToggleSprite>();
        }

        private void Update()
        {
            _sprite.Toggle(_door.IsOpen);
        }

        private ToggleSprite _sprite;
    }
}
