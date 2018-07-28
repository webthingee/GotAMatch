using UnityEngine;

public class IntAct_Switch : MonoBehaviour, IintAct
{
	public void StartUsingInteractable()
	{
		GetComponent<SpriteRenderer>().color = Color.green;
	}

	public void StopUsingInteractable()
	{
		Debug.Log("Walking Away Now");
	}
}