using System;
using UnityEngine;
using MemoTools;


namespace Paws { 
    public class DeathAnimation : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private TriggerAnimation _animation;

        private void Awake()
        {
            _health.OnDeath += OnDie;
            _animation.OnAnimationEnd += OnAnimationEnd;
        }

        private void OnDie(object sender, EventArgs e)
        {
             _animation.Trigger();
        }

        private void OnAnimationEnd(object sender, EventArgs e)
        {
            Destroy(gameObject);
        }
    }
}
