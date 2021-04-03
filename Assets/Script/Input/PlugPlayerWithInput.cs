using UnityEngine;


namespace Paws { 
    public class PlugPlayerWithInput : MonoBehaviour
    {
        [SerializeField] MovementController _player;

        private void Update()
        {
            _player.Move(InputController.Instance.MovementInput);
        }
    }
}
