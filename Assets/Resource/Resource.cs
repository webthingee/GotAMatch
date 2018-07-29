using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool canUse;
    public bool inUse;

	private void OnMouseUp()
    {
		Resource[] A = FindObjectsOfType<Resource>();
        foreach (var a in A)
        {
            a.canUse = false;
            if (a.inUse == true)
			    a.DropResource();
        }

		canUse = true;

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
	    if (canUse) 
	    {
	        PickUpResource();
	    }
	}

	private void LateUpdate()
	{
		if (inUse)
		{
			transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
		}
	}

	private void PickUpResource()
	{
		Debug.Log("PickUp Resource");
		inUse = true;
	}

    private void DropResource()
	{
		Debug.Log("Drop Resource");
		inUse = false;
		transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + Vector3.up;
	}
}