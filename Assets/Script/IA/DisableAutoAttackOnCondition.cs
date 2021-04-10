using UnityEngine;


namespace Paws { 
    [RequireComponent(typeof(AutoAttack))]
    public class DisableAutoAttackOnCondition : MonoBehaviour
    {
        [SerializeField] private MemoTools.Objective _condition;

        private void Awake()
        {
            _autoAttack = GetComponent<AutoAttack>();
        }

        private void Update()
        {
            if(_condition.IsCompleted)
            {
                _autoAttack.enabled = false;
            }
        }

        private AutoAttack _autoAttack;
    }
}
