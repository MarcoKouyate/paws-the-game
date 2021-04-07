using UnityEngine;


namespace Paws { 
    public class AvoidDanger : MonoBehaviour
    {
        [SerializeField] private DangerChecker _dangerChecker;
        [SerializeField] private MovementController _movement;


        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            if (_dangerChecker.IsDetectingDanger)
            {
                Vector2 directionToDanger = GetDangerEpicenter();
                _movement.Move(directionToDanger.normalized);
            }
        }

        private Vector2 GetDangerEpicenter()
        {
            Vector2 epicenter = Vector2.zero;

            foreach(GameObject danger in _dangerChecker.Dangers)
            {
                epicenter += GetDirectionToDanger(danger.transform.position);
            }

            return epicenter;
        }

        private Vector2 GetDirectionToDanger(Vector2 dangerPosition)
        {
            return (Vector2)_transform.position - dangerPosition;
        }

        private Transform _transform;

    }
}
