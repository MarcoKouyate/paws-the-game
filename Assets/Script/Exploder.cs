using UnityEngine;


namespace Paws { 
    public class Exploder : MonoBehaviour
    {
        [SerializeField] private GameObject _explosionPrefab;
        [SerializeField] private float _timer;

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                Explode();
            }
        }

        public void Explode()
        {
            Instantiate(_explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
