using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePosition : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<Interactable>().inUse = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
		GetComponentInParent<Interactable>().inUse = false;
		GetComponentInParent<Interactable>().canUse = false;
    }
}
