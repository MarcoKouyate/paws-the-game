using UnityEngine;


namespace Paws { 
    public class Swappable : MonoBehaviour
    {
        private void Awake()
        {
            _transform = transform;
        }

        public void Swap(Transform other)
        {
            Vector3 temp = _transform.position;
            _transform.position = other.position;
            other.position = temp;
        }

        private Transform _transform;
    }
}
