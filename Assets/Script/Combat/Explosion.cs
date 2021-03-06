using UnityEngine;
using DG.Tweening;


namespace Paws { 
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private float _size;
        [SerializeField] private float _duration;

        private void OnEnable()
        {
            transform.DOScale(transform.localScale * _size, _duration)
                .SetEase(Ease.OutSine)
                .OnComplete(DoDestroy);
        }

        private void DoDestroy()
        {
            Destroy(gameObject);
        }
    }
}
