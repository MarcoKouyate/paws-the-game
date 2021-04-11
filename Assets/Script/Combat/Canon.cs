using UnityEngine;


namespace Paws { 
    public class Canon : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;

        public event System.EventHandler OnShoot;

        private void Awake()
        {
            _transform = transform;
        }

        public void Use()
        {
            Instantiate(_bulletPrefab, _transform.position, _transform.rotation);
            OnShoot?.Invoke(this, System.EventArgs.Empty);
        }

        private Transform _transform;
    }
}
