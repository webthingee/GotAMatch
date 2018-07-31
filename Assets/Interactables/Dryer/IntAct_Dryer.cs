﻿using UnityEngine;

public class IntAct_Dryer : MonoBehaviour, IIntAct
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

    private Key key;

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
            LockOpen();
        }
        else
        {
            Debug.Log("Lock Locked");
        }
    }

    private void LockOpen()
    {
		if (!complete)
        {

            int i = 21;
            foreach (var item in launchables)
            {
                GameObject towel = Instantiate(item, transform.position, transform.rotation);
                towel.GetComponent<Key>().keyID = i;
                towel.name = "Towel #" + i;
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