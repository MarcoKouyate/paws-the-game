using UnityEngine;


namespace Paws { 
    public class TeleportOnCollision : MonoBehaviour
    {
        [SerializeField] private Transform _destination;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_destination) other.transform.position = _destination.position;
        }

        public void SetDestination(Transform destination)
        {
            _destination = destination;
        }
    }
}
