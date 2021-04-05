using UnityEngine;


namespace Paws { 
    public class Swapper : MonoBehaviour
    {

        private void Awake()
        {
            _transform = transform;
        }

        public void Update()
        {
            Swap();
        }

        private void Swap()
        {
            GameObject selectedObject = TouchSelection.Instance.Selected;
            if (selectedObject == null) return;

            Swappable swappable = selectedObject.GetComponent<Swappable>();

            if (swappable == null) return;
            swappable.Swap(_transform);

        }

        private Transform _transform;
    }
}
