using Fungus;
using UnityEngine;

public class IntAct_Dryer : MonoBehaviour, IIntAct
{
    public int lockID;
	public GameObject[] launchables;
	bool complete;

    [Header("Open Reactions")]
    public bool removeLock;
    public bool removeKey;

    private Flowchart flowchart;
    private Key key;
    private int sayInt;

    private void Awake()
    {
        flowchart = GetComponent<Flowchart>();
    }
    
    public void NotInProgress()
    {
        flowchart.SetBooleanVariable("inProgress", false);
        Flowchart.BroadcastFungusMessage("Dryer");
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
        Flowchart.BroadcastFungusMessage("Dryer");
    }
    
    private void UnLocked()
    {
        if (!complete)
        {
            Debug.Log("UnLocked");

            var i = 301;
            foreach (GameObject item in launchables)
            {
                GameObject towel = Instantiate(item, transform.position, transform.rotation);
                towel.GetComponent<Key>().keyID = i;
                towel.name = "Towel #" + i;
                i++;
            }
            
            sayInt = 2;
            complete = true;
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
        Debug.Log("Locked");
        
        if (key != null)     // clicking with something in hand
        {
            sayInt = 1;
            Debug.Log("This is not the right key");  
        }
        else                 // clicking without anything in hand
        {
            sayInt = 0;
            Debug.Log("There is nothing in hand");
        }
    }

    public void StopUsingInteractable()
    {
        //Debug.Log("Walking Away Now");
    }

    private bool CheckActiveResource()
    {
        key = GameObject.FindWithTag("Player").GetComponentInChildren<Key>();

        if (key == null) return false;
        return key.keyID == lockID;
    }
}