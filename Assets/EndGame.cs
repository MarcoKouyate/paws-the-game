using UnityEngine;


namespace Paws { 
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private MemoTools.Objective loseCondition;
        [SerializeField] private MemoTools.Objective winCondition;


        public void Update()
        {
            if (loseCondition.IsCompleted)  {
                Debug.Log("Lose");
            } else
            {
                Debug.Log("Not Lose");
            }
            
            if (winCondition.IsCompleted)
            {
                Debug.Log("Win");
            }
        }
    }
}
