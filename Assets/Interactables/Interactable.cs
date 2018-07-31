using UnityEngine;

public class Interactable : MonoBehaviour
{
	public bool canUse;
	[SerializeField] private bool inUse;

	PointerManager pointerManager;

	public bool InUse
	{
		get
		{
			return inUse;
		}

		set
		{
			inUse = value;
			if (inUse == true && canUse == true) StartUsingInteractable();
			//if (inUse == false) StopUsingInteractable();
		}
	}

    private void Awake()
    {
        pointerManager = FindObjectOfType<PointerManager>();
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

	private void OnMouseOver()
    {
        pointerManager.pointerText = this.name;
		Debug.Log("over");
    }

    private void OnMouseExit()
    {
        pointerManager.pointerText = "";
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