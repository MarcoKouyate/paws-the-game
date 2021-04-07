using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Paws { 
    public class DangerChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask _dangerLayer;

        public List<GameObject> Dangers { get; private set; }
        public bool IsDetectingDanger { get => Dangers.Count > 0; }


        private void Awake()
        {
            Dangers = new List<GameObject>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_dangerLayer != (_dangerLayer | (1 << other.gameObject.layer))) return;

            Dangers.Add(other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_dangerLayer != (_dangerLayer | (1 << other.gameObject.layer))) return;

            Dangers.Remove(other.gameObject);
        }
    }
}
