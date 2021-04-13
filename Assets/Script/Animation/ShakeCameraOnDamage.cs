using UnityEngine;
using System;

namespace Paws { 
    public class ShakeCameraOnDamage : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private CinemachineShaker _cameraShaker;
        [SerializeField] private float _time;
        [SerializeField] private float _intensity;

        private void Awake()
        {
            _health.OnDamage += OnDamage;
        }

        private void OnDamage(object sender, EventArgs e)
        {
            _cameraShaker.Shake(_intensity, _time);
        }
    }
}
