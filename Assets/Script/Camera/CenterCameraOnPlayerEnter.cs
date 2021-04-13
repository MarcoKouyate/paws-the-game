using UnityEngine;


namespace Paws { 
    public class CenterCameraOnPlayerEnter : MonoBehaviour
    {
        [SerializeField] private MemoTools.ScriptableVector2 _cameraPosition;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _cameraPosition.value = transform.position;
            }
        }
    }
}
