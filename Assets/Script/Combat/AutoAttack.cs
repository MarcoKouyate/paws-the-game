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
            _timer = new MemoTools.Timer(_interval, true);
        }

        private void Update()
        {
            if (_timer.OnTimeEnd)
            {
                Attack();
            }
        }
        #endregion

        #region Public Methods
        private void Attack()
        {
            if (!_canon) return;
            _canon.Use();
        }
        #endregion

        #region Private Variables
        private float _nextShotTime;
        private MemoTools.Timer _timer;
        #endregion
    }
}
