using UnityEngine;


namespace Paws { 
    public class FlipHorizontalTowardsPosition : MonoBehaviour
    {
        [SerializeField] private MemoTools.ScriptableVector2 target;

        private void Update()
        {
            if (( transform.position.x - target.value.x) * transform.right.x < 0) transform.Rotate(Vector2.up * 180);
        }
    }
}
