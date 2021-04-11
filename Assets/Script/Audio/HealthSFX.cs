using UnityEngine;
using System;

namespace Paws { 
    public class HealthSFX : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private MemoTools.ScriptableAudio _damageSFX;
        [SerializeField] private MemoTools.ScriptableAudio _deathSFX;

        private void Awake()
        {
            _health.OnDamage += OnDamage;
            _health.OnDeath += OnDie;
        }

        private void OnDamage(object sender, EventArgs e)
        {
            if(_damageSFX) MemoTools.AudioManager.Instance.Play(_damageSFX);
        }

        private void OnDie(object sender, EventArgs e)
        {
            if(_deathSFX) MemoTools.AudioManager.Instance.Play(_deathSFX);
        }
    }
}
