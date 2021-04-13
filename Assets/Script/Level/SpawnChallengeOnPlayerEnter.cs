using UnityEngine;


namespace Paws { 
    public class SpawnChallengeOnPlayerEnter : MonoBehaviour
    {
        [SerializeField] private SpawnRandomChallenge _challenge;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!visited && collision.CompareTag("Player"))
            {
                _challenge.Spawn();
                visited = true;
            }
        }

        private bool visited = false;
    }
}
