using System;
using System.Collections.Generic;
using UnityEngine;


namespace Paws {
    [RequireComponent(typeof(Collider2D))]
    public class CollisionImmunity : MonoBehaviour
    {
        public List<Collider2D> immuneObjects;
        public List<Collider2D> collidedObjects;

        [SerializeField] private ContactFilter2D _contactFilter;
        [SerializeField] private LayerMask _immuneLayers;
        [SerializeField] private bool _protectFromSpawnContact;
        [SerializeField] private int _maxSpawnContact;


        private void Awake()
        {
            collidedObjects = new List<Collider2D>();
            immuneObjects = new List<Collider2D>();
        }

        private void OnEnable()
        {
            collidedObjects.Clear();
            immuneObjects.Clear();

            if (_protectFromSpawnContact)
            {
                AddToImmunity(GetListOfSpawnContacts());
            }
        }

        private Collider2D[] GetListOfSpawnContacts()
        {
            Collider2D collider = GetComponent<Collider2D>();
            Collider2D[] collidersTouchedFromStart = new Collider2D[_maxSpawnContact];
            int count = collider.OverlapCollider(_contactFilter, collidersTouchedFromStart);
            Collider2D[] results = new Collider2D[count];
            Array.Copy(collidersTouchedFromStart, 0, results, 0, results.Length);
            return results;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsImmuneToCollision(collision)) return;
            collidedObjects.Add(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collidedObjects.Contains(collision)) collidedObjects.Remove(collision);
            if (immuneObjects.Contains(collision)) immuneObjects.Remove(collision);
        }

        public void AddToImmunity(Collider2D[] colliders)
        {
            immuneObjects.AddRange(colliders);
        }

        public bool IsImmuneToCollision(Collider2D other)
        {
            return immuneObjects.Contains(other);
        }

        public bool IsImmuneToCollision(int layer)
        {
            return _immuneLayers == (_immuneLayers | (1 << layer));
        }
    }
}
