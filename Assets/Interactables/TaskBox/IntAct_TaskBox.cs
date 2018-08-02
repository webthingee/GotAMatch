using UnityEngine;
using Fungus;

public class IntAct_TaskBox : MonoBehaviour, IIntAct
{
    public int lockID;
	public GameObject[] launchables;
	bool complete;

    [Header("Open Reactions")]
    public bool removeLock;
    public bool removeKey;

    [Header("Task Reactions")]
    public Animator animator;
    public string animatorBool;
    public Interactable[] UnlockInteractables;

    private Flowchart flowchart;
    private Key key;
    private int sayInt;

    private void Awake()
    {
        flowchart = GetComponent<Flowchart>();
        //flowchart.SetBooleanVariable("complete", complete);     

    }

    public void NotInProgress()
    {
        flowchart.SetBooleanVariable("inProgress", false);
        Flowchart.BroadcastFungusMessage("TaskBox");
    }

    public void StartUsingInteractable()
    {
        flowchart.SetBooleanVariable("inProgress", true);
        if (CheckActiveResource())
        {
            UnLocked();
        }
        else
        {
            Locked();
        }
        
        flowchart.SetIntegerVariable("choice", sayInt);     
        Flowchart.BroadcastFungusMessage("TaskBox");
    }
    
    private void UnLocked()
    {
        if (!complete)
        {
//            Debug.Log("UnLocked");

            var i = 11;
            foreach (var item in launchables)
            {
                GameObject workOrder = Instantiate(item, transform.position, transform.rotation);
                workOrder.GetComponent<Key>().keyID = i;

                switch (i)
                {
//                    case 10:
//                        workOrder.name = "Computer Access";
//                        workOrder.GetComponent<Key>().fungusMsg = "WorkOrder10";
//                        break;
                    case 11:
                        workOrder.name = "Dryer Access";
                        workOrder.GetComponent<Key>().fungusMsg = "WorkOrder11";
                        break;
                    default:
                        workOrder.name = "Work Order";
                        break;
                }

                i++;
            }
            
            sayInt = 1;
            complete = true;

            foreach (Interactable unlockInteractable in UnlockInteractables)
            {
                unlockInteractable.inProgress = true;
            }
        }

        if (removeLock)
        {
            flowchart.enabled = false;
        }

        if (removeKey)
        {
            Destroy(key.gameObject);
        }
    }

    private void Locked()
    {
//        Debug.Log("Locked");
        
        if (key != null)     // clicking with something in hand
        {
            sayInt = 2;
            Debug.Log("This is not the right key");  
        }
        else                 // clicking without anything in hand
        {
            sayInt = 0;
//            Debug.Log("There is nothing in hand");
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