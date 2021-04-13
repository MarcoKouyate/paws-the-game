using UnityEngine;
using Cinemachine;

namespace Paws {
    public class CinemachineShaker : MonoBehaviour
    {
        [SerializeField] private Cinemachine.CinemachineVirtualCamera virtualCamera;

        private void Awake()
        {
            _multiChannel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            _timer = _timer = new MemoTools.Timer(0, false);
        }

        public void Shake(float intensity, float time)
        {
            _multiChannel.m_AmplitudeGain = intensity;
            _timer = new MemoTools.Timer(time, false);
        }

        private void Update()
        {
            if(_timer.OnTimeEnd)
            {
                _multiChannel.m_AmplitudeGain = 0;
            }
        }

        private CinemachineBasicMultiChannelPerlin _multiChannel;
        private MemoTools.Timer _timer;
    }
}
