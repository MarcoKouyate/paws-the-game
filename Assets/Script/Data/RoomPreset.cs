using UnityEngine;


namespace Paws {
    [CreateAssetMenu(menuName = "PAWS/GridGeneration/RoomPreset", fileName = "RoomPreset")]
    public class RoomPreset : ScriptableObject
    {
        [SerializeField] private MemoTools.ScriptableGameObjectList ends;
        [SerializeField] private MemoTools.ScriptableGameObjectList starts;
        [SerializeField] private MemoTools.ScriptableGameObjectList enemies;
        [SerializeField] private MemoTools.ScriptableGameObjectList traps;

        public GameObject GetRandomEnemy()
        {
            GameObject enemy = enemies.GetRandomElement();
            return enemy;
        }

        public GameObject GetRandomStart()
        {
            GameObject start = starts.GetRandomElement();
            return start;
        }

        public GameObject GetRandomEnd()
        {
            GameObject end = ends.GetRandomElement();
            return end;
        }
    }
}
