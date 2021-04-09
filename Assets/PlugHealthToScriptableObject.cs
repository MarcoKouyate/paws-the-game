using UnityEngine;


namespace Paws { 
    public class PlugHealthToScriptableObject : MonoBehaviour
    {
        [SerializeField] private MemoTools.ScriptableInt destination;
        [SerializeField] private Health source;

        private void Start()
        {
            destination.value = source.Current;
        }

        private void Update()
        {
            destination.value = source.Current;
        }
    }
}
