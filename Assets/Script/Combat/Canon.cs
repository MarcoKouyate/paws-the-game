using UnityEngine;


namespace Paws { 
    public class Canon : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;

        private void Awake()
        {
            _transform = transform;
        }

        public void Use()
        {
            Instantiate(_bulletPrefab, _transform.position, _transform.rotation);
        }

        private Transform _transform;
    }
}
