using UnityEngine;


namespace Paws { 
    public class TouchSelection : MemoTools.SingletonMonoBehaviour<TouchSelection>
    {
        public GameObject Selected { get; private set; }
        protected override bool DestroyOnLoad { get => false; }

        protected override void InitAwake()
        {
            
        }

        private void Update()
        {
            if (InputController.Instance.OnTouchEnded)
            {
                Vector3 touchPosition = InputController.Instance.TouchPosition;
                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

                if (!hit)
                {
                    Selected = null;
                    return;
                }

                Selected = hit.transform.gameObject;

                Debug.Log(Selected);
            } else
            {
                Selected = null;
            }
        }
    }
}
