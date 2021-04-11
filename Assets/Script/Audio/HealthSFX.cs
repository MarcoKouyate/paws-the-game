using UnityEngine;
using System;

namespace Paws { 
    [RequireComponent(typeof(MemoTools.AudioPlayer))]
    public class HealthSFX : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private MemoTools.ScriptableAudio _damageSFX;
        [SerializeField] private MemoTools.ScriptableAudio _deathSFX;

        private void Awake()
        {
            _health.OnDamage += OnDamage;
            _health.OnDeath += OnDie;
            _audioPlayer = GetComponent<MemoTools.AudioPlayer>();
        }

        private void OnDamage(object sender, EventArgs e)
        {
            if(_damageSFX) _audioPlayer.Play(_damageSFX);
        }

        private void OnDie(object sender, EventArgs e)
        {
            if(_deathSFX) _audioPlayer.Play(_deathSFX);
        }

        private MemoTools.AudioPlayer _audioPlayer;
    }
}
