using UnityEngine;


namespace Paws { 
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Swapper))]
    public class PlayerController : MonoBehaviour
    {
        private void Awake()
        {
            _movement = GetComponent<MovementController>();
            _health = GetComponent<Health>();
            _swapper = GetComponent<Swapper>();
            _health.OnDeath += OnDie;
        }

        public void Move(Vector2 direction)
        {
            if (!_health.IsAlive) return;

            _movement.Move(direction);
        }

        private void OnDie(object sender, System.EventArgs e)
        {
            _swapper.enabled = false;
        }

        private MovementController _movement;
        private Health _health;
        private Swapper _swapper;
    }
}
