using UnityEngine;
using System;

namespace Paws { 
    public class Health : MonoBehaviour
    {
        #region Show In Inspector
        [SerializeField] private int max;
        [SerializeField] private int current;
        #endregion

        #region Properties

        public event EventHandler OnDeath;
        public event EventHandler OnDamage;

        public bool IsAlive
        {
            get => current > 0;
        }

        public int Current
        {
            get => current;
        }
        #endregion

        #region Public Methods
        public void ResetHealth()
        {
            current = max;
            _wasAlive = IsAlive;
        }

        public void Heal(int amount)
        {
            current += amount;
            if (current > max) current = max;
        }

        public void Damage(int amount)
        {
            current -= amount;
            if (current < 0) current = 0;
            OnDamage?.Invoke(this, EventArgs.Empty);
        }

        public void Die()
        {
            _wasAlive = false;
            OnDeath?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Unity Cycle
        private void Awake()
        {
            ResetHealth();
        }

        private void Update()
        {
            if (_wasAlive && !IsAlive) Die();
            _wasAlive = IsAlive;
        }
        #endregion

        private bool _wasAlive;
    }
}
