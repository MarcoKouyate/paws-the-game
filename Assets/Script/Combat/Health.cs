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
        }

        public void Die()
        {
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
            if (!IsAlive) Die();
        }
        #endregion
    }
}
