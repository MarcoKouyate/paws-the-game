using UnityEngine;


namespace Paws { 
    public class TouchSelection : MonoBehaviour
    {
        private void Update()
        {
            if (InputController.Instance.OnTouchEnded)
            {
                Vector3 touchPosition = InputController.Instance.TouchPosition;
                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

                if (!hit) return; 

                Debug.Log($"Select: {hit.transform.name}");
            }
        }
    }
}
