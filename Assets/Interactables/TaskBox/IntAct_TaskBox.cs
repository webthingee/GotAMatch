using UnityEngine;
using Fungus;

public class IntAct_TaskBox : MonoBehaviour, IIntAct
{
    public int lockID;
	public GameObject[] launchables;
	bool complete;
	public Flowchart flowchart;

    [Header("Open Reactions")]
    public bool removeLock;
    public bool removeKey;

    [Header("Task Reactions")]
    public Animator animator;
    public string animatorBool;

    private Key key;

	private void Awake()
	{
		flowchart = GetComponent<Flowchart>();
	}

	public void StartUsingInteractable()
    {
        Debug.Log("Lock Actionable");
		flowchart.SetBooleanVariable("hasKey", false);

        if (CheckActiveResource() == true)
        {
			flowchart.SetBooleanVariable("hasKey", true);
			if (animator)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
                animator.SetBool(animatorBool, true);
            }

            Debug.Log("Lock Open");
            LockOpen();
        }
        else
        {
            Debug.Log("Lock Locked");
        }

		Flowchart.BroadcastFungusMessage("TaskBox");
    }

    private void LockOpen()
    {
		if (!complete)
        {
            if (animator)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
                animator.SetBool(animatorBool, true);
            }

            int i = 10;
            foreach (var item in launchables)
            {
                GameObject workOrder = Instantiate(item, transform.position, transform.rotation);
				workOrder.GetComponent<Key>().keyID = i;
                workOrder.name = "Work Order #" + i;
				i++;
            }

            complete = true;
        }

        if (removeLock)
        {

        }

        if (removeKey)
        {
            Destroy(key.gameObject);
        }
    }

    public void StopUsingInteractable()
    {
        //Debug.Log("Walking Away Now");
    }

    private bool CheckActiveResource()
    {
        key = GameObject.FindWithTag("Player").GetComponentInChildren<Key>();

        if (key != null)
        {
            if (key.keyID == lockID)
            {
                return true;
            }
        }

        return false;
    }
}