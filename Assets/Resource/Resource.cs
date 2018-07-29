using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool canUse;
    public bool inUse;
    
	private void Awake()
	{
		Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), true);
	}

	private void OnMouseUp()
    {
		canUse = true;
    }

	private void Update()
	{
        if (canUse) PlayerChecking();
	}

	private void PickUpResource()
	{
		Debug.Log("PickUp Resource");
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
		canUse = false;
		transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
		transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + Vector3.up;

		inUse = true;
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
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 0.25f);
	}
}