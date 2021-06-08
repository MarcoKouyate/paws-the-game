using UnityEngine;
using UnityEngine.SceneManagement;


namespace Paws
{
    public class ReloadOnSpaceBar : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
