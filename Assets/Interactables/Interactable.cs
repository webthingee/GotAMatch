using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public bool canUse;
	public bool inUse;

	private void OnMouseDown()
	{
		Interactable[] A = FindObjectsOfType<Interactable>();
        foreach (var a in A)
		{
			a.canUse = false;
			a.inUse = false;
		}
	}

	private void OnMouseUp()
	{
		canUse = true;
	}   
}