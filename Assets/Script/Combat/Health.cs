using UnityEngine;


namespace Paws { 
    [RequireComponent(typeof(Death))]
    public class Health : MonoBehaviour
    {
        #region Show In Inspector
        [SerializeField] private int max;
        [SerializeField] private int current;
        #endregion

        #region Properties
        public bool IsAlive
        {
            get => current > 0;
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
        #endregion

        #region Unity Cycle
        private void Awake()
        {
            _death = GetComponent<Death>();
            ResetHealth();
        }

        private void Update()
        {
            if(!IsAlive) _death.Die();
        }
        #endregion

        #region Private Variables
        private Death _death;
        #endregion
    }
}
