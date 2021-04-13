using UnityEngine;


namespace Paws { 
    public class SpawnRandomChallenge : MonoBehaviour
    {
        [SerializeField] private RoomPreset _preset;

        public void Spawn()
        {
            GameObject prefab = _preset.GetRandomEnemy();
            GameObject enemy = Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
