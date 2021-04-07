using UnityEngine;


namespace Paws { 
    public class AvoidDanger : MonoBehaviour
    {
        [SerializeField] private DangerChecker _dangerChecker;
        [SerializeField] private MovementController _movement;


        public void Update()
        {
            if (_dangerChecker.IsDetectingDanger)
            {
                Vector2 dangerPosition = _dangerChecker.Dangers[0].transform.position;
                Vector2 directionToDanger = ((Vector2)transform.position - (Vector2)dangerPosition).normalized;
                Vector2 directionToMove = directionToDanger;
                _movement.Move(directionToMove);

            }
        }

    }
}
