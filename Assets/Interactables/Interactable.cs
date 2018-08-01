using UnityEngine;

public class Interactable : MonoBehaviour
{
	public bool canUse;
	[SerializeField] private bool inUse;
	[SerializeField] public bool inProgress;

	PointerManager pointerManager;

	public bool InUse
	{
		set
		{
			inUse = value;
			if (inProgress && inUse && canUse)
			{
				StartUsingInteractable();
			}
		}
	}

    private void Awake()
    {
        pointerManager = FindObjectOfType<PointerManager>();
    }

	private void OnMouseDown()
	{
		var A = FindObjectsOfType<Interactable>();
        foreach (var a in A)
		{
			a.canUse = false;
			a.InUse = false;
		}
	}

	private void OnMouseUp()
	{
		canUse = true;

		if (!inProgress)
		{
			NotInProgress();
		}
	}  

	private void OnMouseOver()
    {
        pointerManager.pointerText = this.name;
    }

    private void OnMouseExit()
    {
        pointerManager.pointerText = "";
    }

	private void NotInProgress()
	{
		Debug.Log("Not In Progress");
		GetComponent<IIntAct>().NotInProgress();
	}
    private void StartUsingInteractable()
	{
		Debug.Log("Start Using");
		GetComponent<IIntAct>().StartUsingInteractable();
	}

	private void StopUsingInteractable()
    {
        GetComponent<IIntAct>().StopUsingInteractable();
    }
}