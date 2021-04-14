using UnityEngine;


namespace Paws { 

    public class RoomSpawner : MonoBehaviour
    {
        [SerializeField] private Room roomPrefab;

        private void Start()
        {
            Collider2D collider = Physics2D.OverlapPoint(transform.position);

            if (collider && !collider.CompareTag("Player")) return;

            Debug.Log("Spawn");

            Room room = Instantiate(roomPrefab, transform.position, transform.rotation);
            if(caller) room.Link(caller);

            room.Init(_distanceFromStart);
        }

        public void LinkTo(DoorSpawn door, int distanceFromStart)
        {
            caller = door;
            _distanceFromStart = distanceFromStart + 1;
        }

        DoorSpawn caller;
        int _distanceFromStart = 0;
    }
}
