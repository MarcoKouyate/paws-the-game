using UnityEngine;


namespace Paws {
    [CreateAssetMenu(menuName = "PAWS/GridGeneration/RoomPreset", fileName = "RoomPreset")]
    public class RoomPreset : ScriptableObject
    {
        [SerializeField] private MemoTools.ScriptableGameObjectList enemies;
        [SerializeField] private MemoTools.ScriptableGameObjectList traps;

        public GameObject GetRandomEnemy()
        {
            GameObject enemy = enemies.GetRandomElement();
            Debug.Log(enemy);
            return enemy;
        }
    }
}
