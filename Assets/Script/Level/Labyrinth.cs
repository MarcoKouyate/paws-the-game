using UnityEngine;


namespace Paws { 
    public class Labyrinth : MonoBehaviour
    {
        [SerializeField] private GridData _gridData;

        private void Awake()
        {
            _gridData.Reset();
        }
    }
}
