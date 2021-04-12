using UnityEngine;


namespace Game { 
    public class Labyrinth : MonoBehaviour
    {
        [SerializeField] private int _count;
        [SerializeField] private MemoTools.ScriptableInt _remainingRooms;
        [SerializeField] private int seed;

        private void Awake()
        {
            _remainingRooms.value = _count;
            

            Random.InitState(seed);
        }
    }
}
