using UnityEngine;


namespace Paws { 
    public class IsActiveOnCondition : MonoBehaviour
    {
        [SerializeField] private MemoTools.Objective objective;
        [SerializeField] private GameObject target;

        [Tooltip("Check this is you want to inverse true with false.")]
        [SerializeField] private bool inverse;

        private void Update()
        {
            bool isActive = inverse ? objective.IsCompleted : !(objective.IsCompleted);
            if(objective == null) Debug.Log(gameObject.name);
            target.SetActive(isActive);
        }
    }
}
