using System.Collections.Generic;
using UnityEngine;


namespace Paws { 
    [RequireComponent(typeof(Collider2D))]
    public class MakeDamageOnCollision : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private ContactFilter2D _contactFilter;

        private void Awake()
        {
            Collider2D collider = GetComponent<Collider2D>();
            Collider2D[] collidersTouchedFromStart = new Collider2D[10];
            collider.OverlapCollider(_contactFilter, collidersTouchedFromStart);
            _collidersImmuneToCollision = new List<Collider2D>(collidersTouchedFromStart);
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsImmuneToCollision(other)) return;

            Damage(other);
            Destroy(gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(IsImmuneToCollision(other))
            {
                _collidersImmuneToCollision.Remove(other);
            }
        }

        private bool IsImmuneToCollision(Collider2D other)
        {
            return _collidersImmuneToCollision.Contains(other);
        }

        private void Damage(Collider2D other)
        {
            Health health = other.GetComponent<Health>();

            if (!health) return;

            health.Damage(_damage);
        }

        private List<Collider2D> _collidersImmuneToCollision;
    }
}
