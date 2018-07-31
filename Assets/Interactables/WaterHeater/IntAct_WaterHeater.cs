using UnityEngine;
using Fungus;

public class IntAct_WaterHeater : MonoBehaviour, IIntAct
{
    public int lockID;
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
		flowchart.SetIntegerVariable("statusInt", 0);
    }
    
    public void StartUsingInteractable()
    {
        if (CheckActiveResource() == true)
        {
			flowchart.SetIntegerVariable("statusInt", 2);

            Debug.Log("Lock Open");
            LockOpen();
        }
        else
        {
			if (flowchart.GetIntegerVariable("statusInt") <= 1)
				flowchart.SetIntegerVariable("statusInt", 1);
			Debug.Log("Lock Locked");
        }

		Flowchart.BroadcastFungusMessage("WaterHeater");




    }

    private void LockOpen()
    {
        if (!complete)
        {

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