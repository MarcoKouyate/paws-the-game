using UnityEngine;
using System;


namespace Paws { 
    [RequireComponent(typeof(Health))]
    public class DestroyOnDeath : MonoBehaviour
    {
        private void Awake()
        {
            Health health = GetComponent<Health>();
            health.OnDeath += OnDie;
        }

        private void OnDie(object sender, EventArgs e)
        {
            Destroy(gameObject);
        }
    }
}
