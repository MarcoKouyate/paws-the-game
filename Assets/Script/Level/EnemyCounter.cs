using UnityEngine;


namespace Paws { 
    public class EnemyCounter : MonoBehaviour
    {
        [SerializeField] private MemoTools.ScriptableInt enemyCount;

        private void Start()
        {
            enemyCount.value = Count();
        }

        public int Count()
        {
            return GameObject.FindGameObjectsWithTag("Enemy").Length;
        }
    }
}
