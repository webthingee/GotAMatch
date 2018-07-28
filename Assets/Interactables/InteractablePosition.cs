using UnityEngine;

public class InteractablePosition : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<Interactable>().InUse = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
		GetComponentInParent<Interactable>().InUse = false;
		GetComponentInParent<Interactable>().canUse = false;
    }
}