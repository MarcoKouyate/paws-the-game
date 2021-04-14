using UnityEngine;
using System.Collections.Generic;

namespace Paws { 
    public class Room : MonoBehaviour
    {
        [Header("Doors")]
        [SerializeField] private DoorSpawn[] nextDoors;

        [Header("Grid")]
        [SerializeField] private bool random;
        [SerializeField] private float offset;
        [SerializeField] private RoomSpawner neighbourPrefab;
        [SerializeField] private GridData gridData;
        public int _distanceFromStart;


        private void Awake()
        {
            _availableDoors = new List<DoorSpawn>(nextDoors);

        }
        
        public void Link(DoorSpawn other)
        {
            DoorSpawn door = GetMatchingDoor(other);
            _availableDoors.Remove(door);
            door.Door.Link(other.Door);
            door.SetOffSet(-other.Offset);
        }

        public void Init(int distanceFromStart)
        {
            int doorMax = (random) ? Random.Range(1, _availableDoors.Count) : _availableDoors.Count;
            if (doorMax > 2) doorMax = 2;
            int doorCount = 0;
            _distanceFromStart = distanceFromStart;

            if (distanceFromStart >= gridData.info.distanceFromStart) gridData.info.distanceFromStart = distanceFromStart;

            while (_availableDoors.Count > 0 && gridData.info.remainingRoomCount > 0 && doorCount <= doorMax)
            {
                    int random = Random.Range(0, _availableDoors.Count);
                    DoorSpawn door = _availableDoors[random];
                    _availableDoors.Remove(door);
                    gridData.info.remainingRoomCount--;
                    doorCount++;
                    RoomSpawner neighbour = Instantiate(neighbourPrefab, GetNextRoomPosition(door), Quaternion.identity);
                    neighbour.LinkTo(door, distanceFromStart);
            }

            //Clear
            foreach(DoorSpawn door in _availableDoors)
            {
                Destroy(door.gameObject);
            }

            _availableDoors.Clear();
        }


        private DoorSpawn GetMatchingDoor(DoorSpawn other)
        {
            foreach (DoorSpawn door in _availableDoors)
            {
                if (((other.Direction.horizontal + door.Direction.horizontal) == 0) && (((other.Direction.vertical + door.Direction.vertical) == 0)))
                {
                    return door;
                }
            }

            return null;
        }


        private Vector2 GetNextRoomPosition(DoorSpawn door)
        {
            Vector2 relativePos = door.transform.position - transform.position;

            Vector2 size = new Vector2((relativePos.x + door.Direction.horizontal * offset), (relativePos.y + door.Direction.vertical * offset));

            return (Vector2)transform.position + size * 2;
        }

        private List<DoorSpawn> _availableDoors;

    }
}
