using UnityEngine;


namespace Paws { 
    public class PlugPositionToScriptableObject : MonoBehaviour
    {
        [SerializeField] private MemoTools.ScriptableVector2 _position;
        [SerializeField] private bool read = true;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            if (read)
            {
                _transform.position = _position.value;
            } else
            {
                _position.value = _transform.position;
            }
        }

        private Transform _transform;
    }
}
