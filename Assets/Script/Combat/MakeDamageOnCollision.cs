using System.Collections.Generic;
using UnityEngine;


namespace Paws { 
    [RequireComponent(typeof(CollisionImmunity))]
    public class MakeDamageOnCollision : MonoBehaviour
    {
        #region Show In Inspector
        [SerializeField] private int _damage;
        [SerializeField] private bool _disableOnImpact;
        #endregion


        #region Unity Cycle

        private void Awake()
        {
            _collisionImmunity = GetComponent<CollisionImmunity>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_collisionImmunity.IsImmuneToCollision(other) || _collisionImmunity.IsImmuneToCollision(other.gameObject.layer)) return;

            Damage(other);
            if(_disableOnImpact) gameObject.SetActive(false);
        }

        #endregion


        #region Private Methods

        private void Damage(Collider2D other)
        {
            Health health = other.GetComponent<Health>();

            if (!health) return;

            health.Damage(_damage);
        }
        #endregion

        private CollisionImmunity _collisionImmunity;
    }
}
