using UnityEngine;
using Fungus;

public class Resource : MonoBehaviour
{
	public string title;
	public bool canUse;
    public bool inUse;

	private PointerManager pointerManager;
    
	private void Awake()
	{
		Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), true);
		pointerManager = FindObjectOfType<PointerManager>();
	}

	private void OnMouseDown()
	{
		Resource[] A = FindObjectsOfType<Resource>();
        foreach (var a in A)
        {
            a.canUse = false;
            if (a.inUse == true)
                a.DropResource();
        }
	}

	private void OnMouseUp()
    {
		canUse = true;
    }
	
	private void OnMouseOver()
	{
		var displayName = title != "" ? title : name;
		pointerManager.pointerText = displayName;
	}

	private void OnMouseExit()
	{
		pointerManager.pointerText = "";
	}

	private void Update()
	{
        if (canUse) PlayerChecking();
	}
    
	private void PickUpResource()
	{
//		Debug.Log("PickUp Resource");
        GetComponent<BoxCollider2D>().enabled = false;
		GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Rigidbody2D>().isKinematic = true;

		var key = GetComponent<Key>();
		if (key != null)
		{
			Flowchart.BroadcastFungusMessage(key.fungusMsg);
		}

		canUse = false;
		inUse = true;

		transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
		transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + Vector3.up;
	}

    public void DropResource()
	{
		Debug.Log("Drop Resource");
		GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().isKinematic = false;

		canUse = false;
		inUse = false;

		transform.parent = null;
		transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + Vector3.up - transform.right;
	}

	private void PlayerChecking()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.25f, 1 << LayerMask.NameToLayer("Player"));
        
		if (hit && canUse)
        {
			PickUpResource();
        }
    }
    
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0.93f, 0.55f, 0.07f);
		Gizmos.DrawWireSphere(transform.position, 0.25f);
	}
}