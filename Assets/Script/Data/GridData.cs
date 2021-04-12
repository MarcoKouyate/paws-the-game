using UnityEngine;


namespace Paws { 
    public struct GridGenerationInfo
    {
        public int remainingRoomCount;
        public int distanceFromStart;
        public int remainingGoalCount;
    }

    [CreateAssetMenu(menuName = "PAWS/GridGeneration/GridData", fileName = "Grid Data")]
    public class GridData : ScriptableObject
    {
        public int seed;
        public int roomCount;
        public int goalCount;

        public GridGenerationInfo info;

        public void Reset() {
            info.distanceFromStart = 0;
            info.remainingGoalCount = goalCount;
            info.remainingRoomCount = roomCount;
            Random.InitState(seed);
        }
    }
}
