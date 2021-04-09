using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Paws { 
    [RequireComponent(typeof(Collision2D))]
    public class DangerChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask _dangerLayer;

        public List<GameObject> Dangers { get; private set; }
        public bool IsDetectingDanger { get => Dangers.Count > 0; }


        private void Awake()
        {
            Dangers = new List<GameObject>();
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_dangerLayer != (_dangerLayer | (1 << other.gameObject.layer))) return;

            CollisionImmunity immunity = other.GetComponent<CollisionImmunity>();

            if (immunity != null && immunity.IsImmuneToCollision(_collider)) return;

            Dangers.Add(other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_dangerLayer != (_dangerLayer | (1 << other.gameObject.layer))) return;

            Dangers.Remove(other.gameObject);
        }

        private Collider2D _collider;
    }
}
