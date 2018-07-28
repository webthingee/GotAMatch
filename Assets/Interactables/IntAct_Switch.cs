using UnityEngine;

public class IntAct_Switch : MonoBehaviour, IIntAct
{
	public Animator animator;
	public string animatorBool;

	public void StartUsingInteractable()
	{
		if (animator)
		{
			GetComponent<SpriteRenderer>().color = Color.green;
            animator.SetBool(animatorBool, true);
		}
	}

	public void StopUsingInteractable()
	{
		Debug.Log("Walking Away Now");
	}
}