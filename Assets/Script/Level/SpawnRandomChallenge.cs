using UnityEngine;


namespace Paws
{
    public enum RoomType { Start, Enemy, End }

    public class SpawnRandomChallenge : MonoBehaviour
    {
        [SerializeField] private GridData _grid;
        [SerializeField] private RoomPreset _preset;
        [SerializeField] private Room _room;
        [SerializeField] private RoomType _type;

        public void Spawn()
        {
            if (_room._distanceFromStart == 0)
            {
                _type = RoomType.Start;
            }
            else if (_room._distanceFromStart >= _grid.info.distanceFromStart && _grid.info.remainingGoalCount > 0)
            {
                _grid.info.remainingGoalCount--;
                _type = RoomType.End;
            }
            else
            {
                _type = RoomType.Enemy;
            }

            GameObject prefab;

            switch (_type)
            {
                case RoomType.Start:
                    prefab = _preset.GetRandomStart();
                    break;
                case RoomType.Enemy:
                    prefab = _preset.GetRandomEnemy();
                    float random = Random.Range(0f, 1f);
                    if(random > 0.5)
                    {
                        Instantiate(_preset.GetRandomTrap(), transform.position, transform.rotation);
                    }
                    break;
                case RoomType.End:
                    prefab = _preset.GetRandomEnd();
                    break;
                default:
                    prefab = null;
                    break;
            }

            if (!prefab) return;

            GameObject challenge = Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
