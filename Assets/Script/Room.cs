using UnityEngine;


namespace Paws { 
    public class Room : MonoBehaviour
    {
        [Header("Doors")]
        [SerializeField] private DoorSpawn top;
        [SerializeField] private DoorSpawn right;
        [SerializeField] private DoorSpawn bottom;
        [SerializeField] private DoorSpawn left;
    }
}
