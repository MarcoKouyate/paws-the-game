using UnityEngine;

namespace Paws { 

    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        #region Show In Inspector
        [SerializeField] private float _moveSpeed;
        #endregion

        #region Public Methods
        public void Move(Vector2 direction)
        {
            _moveDirection = direction;
        }
        #endregion

        #region Unity Cycle
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _moveDirection = Vector2.zero;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _moveDirection * 100 * Time.fixedDeltaTime * _moveSpeed;
            _moveDirection = Vector2.zero;
        }
        #endregion

        #region Private Variables
        private Rigidbody2D _rigidbody;
        private Vector2 _moveDirection;
        #endregion
    }
}