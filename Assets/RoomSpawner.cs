using UnityEngine;


namespace Paws { 

    public class RoomSpawner : MonoBehaviour
    {
        [SerializeField] private Room roomPrefab;

        private void Start()
        {
            if(Physics2D.OverlapPoint(transform.position)) return;
            Room room = Instantiate(roomPrefab, transform.position, transform.rotation);
            if(caller) room.Link(caller);

            room.Init();
        }

        public void LinkTo(DoorSpawn door)
        {
            caller = door;
        }

        DoorSpawn caller;
    }
}
