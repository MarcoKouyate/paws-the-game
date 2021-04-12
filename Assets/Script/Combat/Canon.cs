using UnityEngine;


namespace Paws { 
    public class Canon : MonoBehaviour
    {
        [SerializeField] private MemoTools.ObjectPool _objectPool;

        public event System.EventHandler OnShoot;

        private void Awake()
        {
            _transform = transform;
        }

        public void Use()
        {
            _objectPool.Take( _transform.position, _transform.rotation);
            OnShoot?.Invoke(this, System.EventArgs.Empty);
        }

        private Transform _transform;
    }
}
