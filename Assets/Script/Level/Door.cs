using UnityEngine;


namespace Paws { 

    public class Door : MonoBehaviour
    {
        [SerializeField] private TeleportOnCollision _teleporter;
        [SerializeField] private Transform _spawn;

        public TeleportOnCollision Teleporter { get => _teleporter; }
        public Transform Spawn { get => _spawn; }

        public void Link(Door other)
        {
            other.Teleporter.SetDestination(_spawn);
            _teleporter.SetDestination(other.Spawn);
        }
    }
}
