using UnityEngine;
using System;

namespace Paws { 
    public class ShakeCameraOnDamage : MonoBehaviour
    {
        [SerializeField] private MilkShake.ShakePreset _preset;
        [SerializeField] private Health _health;

        private void Awake()
        {
            _shaker = Camera.main.GetComponent<MilkShake.Shaker>();
            _health.OnDamage += OnDamage;
        }

        private void OnDamage(object sender, EventArgs e)
        {
            _shaker.Shake(_preset);
        }

        private MilkShake.Shaker _shaker;
    }
}
