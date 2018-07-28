using UnityEngine;

public class Interactable : MonoBehaviour
{
	public bool canUse;
	[SerializeField] private bool inUse;

	public bool InUse
	{
		get
		{
			return inUse;
		}

		set
		{
			inUse = value;
			if (inUse == true) StartUsingInteractable();
		}
	}

	private void OnMouseDown()
	{
		Interactable[] A = FindObjectsOfType<Interactable>();
        foreach (var a in A)
		{
			a.canUse = false;
			a.InUse = false;
		}
	}

	private void OnMouseUp()
	{
		canUse = true;
	}  

    private void StartUsingInteractable()
	{
		GetComponent<IIntAct>().StartUsingInteractable();
	}

	private void StopUsingInteractable()
    {
        GetComponent<IIntAct>().StopUsingInteractable();
    }
}