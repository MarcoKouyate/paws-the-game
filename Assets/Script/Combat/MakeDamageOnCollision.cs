using System.Collections.Generic;
using UnityEngine;


namespace Paws { 
    [RequireComponent(typeof(Collider2D))]
    public class MakeDamageOnCollision : MonoBehaviour
    {
        #region Show In Inspector
        [SerializeField] private int _damage;
        [Tooltip("Check this if it shouldn't collide with colliders overlapping when spawned")]
        [SerializeField] private bool _protectFromSpawnContact;
        [SerializeField] private bool _destroyOnImpact;
        [SerializeField] private ContactFilter2D _contactFilter;
        #endregion


        #region Unity Cycle
        private void Awake()
        {
            if (_protectFromSpawnContact) RegisterSpawnContacts();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_protectFromSpawnContact && IsImmuneToCollision(other)) return;

            Damage(other);

            if(_destroyOnImpact) Destroy(gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(_protectFromSpawnContact && IsImmuneToCollision(other))
            {
                _collidersImmuneToCollision.Remove(other);
            }
        }
        #endregion


        #region Private Variables
        private void RegisterSpawnContacts()
        {
            Collider2D collider = GetComponent<Collider2D>();
            Collider2D[] collidersTouchedFromStart = new Collider2D[10];
            collider.OverlapCollider(_contactFilter, collidersTouchedFromStart);
            _collidersImmuneToCollision = new List<Collider2D>(collidersTouchedFromStart);
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
        #endregion


        #region Private Variables
        private List<Collider2D> _collidersImmuneToCollision;
        #endregion
    }
}
