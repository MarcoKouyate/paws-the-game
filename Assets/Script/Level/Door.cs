using UnityEngine;


namespace Paws { 

    public class Door : MonoBehaviour
    {
        [SerializeField] private TeleportOnCollision _teleporter;
        [SerializeField] private Transform _spawn;
        [SerializeField] private MemoTools.Objective _conditionToOpen;

        public TeleportOnCollision Teleporter { get => _teleporter; }
        public Transform Spawn { get => _spawn; }

        public bool IsOpen { get => _conditionToOpen.IsCompleted; }

        public void Link(Door other)
        {
            other.Teleporter.SetDestination(_spawn);
            _teleporter.SetDestination(other.Spawn);
        }

        private void Update()
        {
            _teleporter.gameObject.SetActive(IsOpen);
        }
    }
}
