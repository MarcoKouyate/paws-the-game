using UnityEngine;


namespace Paws { 

    public class DoorSpawn : MonoBehaviour
    {
        #region Show In Inspector
        [SerializeField] private Door _doorPrefab;
        [SerializeField] private CoordinateDirection _direction;

        public float Width;
        #endregion

        #region Properties
        public CoordinateDirection Direction { get => _direction; }

        public Door Door { get; private set; }
        #endregion

        public float Offset { get; private set; }
        
        private void Awake()
        {
            Spawn(Width / 2);

        }

        private void Spawn(float offset)
        {
            Door = Instantiate(_doorPrefab, transform);
            SetOffSet(Random.Range(-1, 1) * offset);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, transform.position - transform.up);
            Vector3 offset = transform.right * Width / 2;
            Gizmos.DrawLine(transform.position - offset, transform.position + offset);
        }

        public void SetOffSet(float offset)
        {
            Offset = offset;
            Door.transform.position = (Vector2) transform.position + (Vector2) Door.transform.right * Offset;
        }

        private void OnDestroy()
        {
            Destroy(Door);
        }


    }
}
