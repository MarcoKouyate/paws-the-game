using MemoTools;
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

        private void FixedUpdate()
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
                epicenter += danger.CompareTag("Bullet") ? GetPointOfImpact(danger.transform) : GetDirectionToDanger(danger.transform.position);
            }

            return epicenter;
        }


        private Vector2 GetPointOfImpact(Transform danger)
        {
            Vector2 directionToDanger = GetDirectionToDanger(danger.position);
            Vector2 bulletDirection = danger.up;
            float angle = Vector2.Angle(directionToDanger, bulletDirection);
            float cosinus = Mathf.Cos(angle * Mathf.Deg2Rad);
            float adjacent = directionToDanger.magnitude * cosinus;
            _pointOfImpact = (Vector2)danger.position + bulletDirection.normalized * adjacent;
            Vector2 directionToImpact = GetDirectionToDanger(_pointOfImpact);

            if(!MemoTools.Utilities.IsVectorActive(directionToImpact, 0.1f))
            {
                directionToImpact = GetDirectionToDanger(_transform.position + danger.right * 0.1f);
            }

            return directionToImpact;
        }

        private Vector2 GetDirectionToDanger(Vector2 dangerPosition)
        {
            return (Vector2)_transform.position - dangerPosition;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(_pointOfImpact, 0.2f); ;
        }

        private Vector2 _pointOfImpact;
        private Transform _transform;

    }
}
