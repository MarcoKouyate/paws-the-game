using UnityEngine;


namespace Paws { 
    public class DoorSpawn : MonoBehaviour
    {
        [SerializeField] private Door _doorPrefab;
        public float Width;

        public float Offset { get; private set; }
        
        private void Awake()
        {
            Spawn(Width / 2);
        }

        private void Spawn(float offset)
        {
            Offset = Random.Range(-1, 1) * offset;
            Door door = Instantiate(_doorPrefab, transform);
            door.transform.Translate(Vector2.right *  Offset);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, transform.position - transform.up);
            Vector3 offset = transform.right * Width / 2;
            Gizmos.DrawLine(transform.position - offset, transform.position + offset);
        }
    }
}
