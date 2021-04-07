using UnityEngine;

namespace Paws { 
    public class Death : MonoBehaviour
    {
        public void Die()
        {
            Destroy(gameObject);
        }
    }
}
