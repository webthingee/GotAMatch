using Fungus;
using UnityEngine;

public class IntAct_DeskWorker : MonoBehaviour, IIntAct
{
    public int lockID;
	public GameObject[] launchables;
	bool complete;
    public Interactable[] UnlockInteractables;

    [Header("Open Reactions")]
    public bool removeLock;
    public bool removeKey;

    private Flowchart flowchart;
    public int key;
    private int sayInt;
    public GameObject winCanvas;

    private void Awake()
    {
        flowchart = GetComponent<Flowchart>();
    }

    public void UnlockStuff()
    {
        foreach (Interactable unlockInteractable in UnlockInteractables)
        {
            unlockInteractable.inProgress = true;
        }
    }   
    
    public void NotInProgress()
    {
        flowchart.SetBooleanVariable("inProgress", false);
        flowchart.SetIntegerVariable("choice", 0);
        Flowchart.BroadcastFungusMessage("DeskWorker");
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
        Flowchart.BroadcastFungusMessage("DeskWorker");
    }
    
    private void UnLocked()
    {
        if (!complete)
        {
            Debug.Log("UnLocked");
            
            sayInt = 2;
            complete = true;
        }

        if (removeLock)
        {
            flowchart.enabled = false;
        }
    }

    private void Locked()
    {
        Debug.Log("Locked");

        sayInt = 1;
    }

    public void StopUsingInteractable()
    {
        //Debug.Log("Walking Away Now");
    }

    private bool CheckActiveResource()
    {
        if (key == null) return false;
        return key == lockID;
    }

    public void Win()
    {
        winCanvas.SetActive(true);
    }
}