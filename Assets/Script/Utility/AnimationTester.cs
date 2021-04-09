using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Have to use a struct instead of a dictionary to serialize the data
[System.Serializable]
public struct StateTrigger
{
    public string name;
    public KeyCode triggerKey;
}

public class AnimationTester : MonoBehaviour
{
    public StateTrigger[] stateTriggers;
    private Animator myAnimator = null;

	private void Awake()
	{
        myAnimator = GetComponent<Animator>();
        if(myAnimator == null)
		{
            Debug.LogError("Please add an animator component to " + gameObject.name);
		}
	}

	// Update is called once per frame
	void Update()
    {
        foreach (StateTrigger state in stateTriggers)
        {
            if(Input.GetKeyDown(state.triggerKey))
			{
                myAnimator.Play(state.name);
			}
        }
    }
}
