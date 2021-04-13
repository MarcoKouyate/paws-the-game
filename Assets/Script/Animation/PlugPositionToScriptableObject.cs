using UnityEngine;


namespace Paws { 
    public class PlugPositionToScriptableObject : MonoBehaviour
    {
        [SerializeField] private MemoTools.ScriptableVector2 _position;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            _transform.position = _position.value;
        }

        private Transform _transform;
    }
}
