using UnityEngine;


namespace Paws { 
    public class RotateTowardsPlayer : MonoBehaviour
    {
        [Tooltip("Check true if your want the game object to follow perfectly the player position without delay")]
        [SerializeField] private bool _instantRotation;

        [Tooltip("Rotation speed is only relevant if instant rotation is unchecked")]
        [SerializeField] private float _rotationSpeed;


        private void Awake()
        {
            FindPlayer();
            _transform = transform;
        }

        private void Update()
        {
            TurnTowardsPlayer();
        }

        private void FindPlayer()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player == null) return;
            _playerTransform = player.transform;
        }

        private void TurnTowardsPlayer()
        {
            if (_playerTransform == null) return;


            float offset = 90f;
            Vector2 direction =  (Vector2)_transform.position - (Vector2)_playerTransform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(Vector3.forward * (angle + offset));

            if(!_instantRotation)
            {
                float step = _rotationSpeed * Time.deltaTime * 100;
                rotation = Quaternion.RotateTowards(_transform.rotation, rotation, step);
            }


            _transform.rotation = rotation;
        }

        private Transform _playerTransform;
        private Transform _transform;
    }
}
