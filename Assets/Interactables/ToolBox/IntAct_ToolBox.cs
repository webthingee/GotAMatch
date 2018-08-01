using UnityEngine;

public class IntAct_ToolBox : MonoBehaviour, IIntAct
{
	public GameObject[] launchables;

	public Animator animator;
	public string animatorBool;

	private bool complete = false;

	public void NotInProgress()
	{
		Debug.Log("Toolbox not active yet");
	}

	public void StartUsingInteractable()
	{
		if (!complete)
		{
			if (animator)
			{
				GetComponent<SpriteRenderer>().color = Color.green;
				animator.SetBool(animatorBool, true);
			}
			
			foreach (var item in launchables)
			{
				Instantiate(item, transform.position, transform.rotation);
			}

			complete = true;
        }
	}

	public void StopUsingInteractable()
	{
		//Debug.Log("Walking Away Now");
	}
}