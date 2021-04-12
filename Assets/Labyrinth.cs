using UnityEngine;


namespace Game { 
    public class Labyrinth : MonoBehaviour
    {
        [SerializeField] private int _count;
        [SerializeField] private MemoTools.ScriptableInt _remainingRooms;

        private void Awake()
        {
            _remainingRooms.value = _count;
            const int initialSeed = 1234;

            Random.InitState(initialSeed);
        }
    }
}
