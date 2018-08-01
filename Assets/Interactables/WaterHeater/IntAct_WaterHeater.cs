using UnityEngine;
using Fungus;

public class IntAct_WaterHeater : MonoBehaviour, IIntAct
{
    public int lockID;
	private bool complete;

    [Header("Open Reactions")]
    public bool removeLock;
    public bool removeKey;

    private Flowchart flowchart;
    private Key key;
    private int sayInt;

    public Interactable[] UnlockInteractables;

    private void Awake()
    {
        flowchart = GetComponent<Flowchart>();
    }

    public void NotInProgress()
    {
      Debug.Log("waterheater not active yet");      
    }

    public void StartUsingInteractable()
    {
        if (CheckActiveResource())
        {
            UnLocked();
        }
        else
        {
            Locked();
        }
        
        flowchart.SetIntegerVariable("choice", sayInt);     
		Flowchart.BroadcastFungusMessage("WaterHeater");
    }

    private void UnLocked()
    {
        if (!complete)
        {
            Debug.Log("UnLocked");

            sayInt = 2;
            complete = true;
            
            foreach (Interactable unlockInteractable in UnlockInteractables)
            {
                unlockInteractable.inProgress = true;
            }
        }

        if (removeLock) {}

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
        return key != null && key.keyID == lockID;
    }
}