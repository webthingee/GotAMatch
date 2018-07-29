using UnityEngine;

public class IntAct_Lock : MonoBehaviour, IIntAct
{
	public int lockID;
	public Animator animator;
    public string animatorBool;

    public void StartUsingInteractable()
    {
		Debug.Log("Lock Actionable");

		if (CheckActiveResource() == true)
		{
			if (animator)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
                animator.SetBool(animatorBool, true);
            }

			Debug.Log("Lock Open");
		}
    }

    public void StopUsingInteractable()
    {
        //Debug.Log("Walking Away Now");
    }

	private bool CheckActiveResource()
    {
        Resource[] A = FindObjectsOfType<Resource>();
        
		foreach (var a in A)
        {
            if (a.inUse == true)
            {
                if (lockID == a.GetComponent<Key>().keyID)
                {
					return true;
                }
                else
                {
					return false;
                }
            }
        }

		return false;
    }
}