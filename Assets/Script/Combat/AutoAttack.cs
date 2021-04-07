using UnityEngine;


namespace Paws { 
    public class AutoAttack : MonoBehaviour
    {
        #region Show in inspector
        [SerializeField] private Canon _canon;
        [SerializeField] float _interval;
        #endregion

        #region Unity Cycle
        private void Awake()
        {
            _nextShotTime = Time.time;
        }

        private void Update()
        {
            if (isTimerExpired())
            {
                ResetTimer();
                Attack();
            }
        }
        #endregion

        #region Private Methods
        private bool isTimerExpired()
        {
            return Time.time > _nextShotTime;
        }

        private void ResetTimer()
        {
            _nextShotTime = Time.time + _interval;
        }

        private void Attack()
        {
            if (!_canon) return;
            _canon.Use();
        }
        #endregion

        #region Private Variables
        private float _nextShotTime;
        #endregion
    }
}
