using UnityEngine;


namespace Paws {
    [System.Serializable]
    public struct CoordinateDirection
    {
        public string state;
        [Range(-1, 1)] public int horizontal;
        [Range(-1, 1)] public int vertical;
    }

    [RequireComponent(typeof(Animator))]
    public class MovementAnimationController : MonoBehaviour
    {
        [SerializeField] private CoordinateDirection[] coordinates;

        public void Move(Vector2 direction)
        {
            _direction = direction;
            if (direction.x * transform.right.x < 0) Flip();
        }

        private void Flip()
        {
           transform.Rotate(Vector2.up * 180);
        }


        #region Unity Cycle
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            foreach(CoordinateDirection coordinate in coordinates)
            {
                if (_direction.x < 0) _direction.x = _direction.x * -1;
                if(SameSign(coordinate.horizontal, _direction.x) && SameSign(coordinate.vertical, _direction.y))
                {
                    _animator.Play(coordinate.state);
                }
            }
        }
        #endregion

        private bool SameSign(float num1, float num2)
        {
            return num1 > 0 && num2 > 0 || num1 < 0 && num2 < 0 || num1 == 0 && num2 == 0;
        }

        #region Private variables
        private Animator _animator;
        private Vector2 _direction;
        #endregion
    }
}
