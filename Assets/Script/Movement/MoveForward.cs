using UnityEngine;


namespace Paws { 
    [RequireComponent(typeof(Rigidbody2D))]
    public class MoveForward : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = transform.up * _moveSpeed * Time.fixedDeltaTime * 100;
        }

        private Rigidbody2D _rigidbody;
    }
}
