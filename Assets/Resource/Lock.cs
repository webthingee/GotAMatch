using UnityEngine;
using UnityEngine.Events;

public class Lock : MonoBehaviour
{
    public int lockID;
    [Tooltip("Open on contact, not an action")] public bool easyOpen;
    [SerializeField] private bool isOpen;

    [Header("Open Reactions")]
    public bool removeLock;
    public bool removeKey;
    public UnityEvent openEvent;
    public UnityEvent unopenEvent;

    private bool isActionable;

    private void Update()
    {
        if (Openable())
        {
            if (!easyOpen)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    TurnTheKey();
                }
            }
            else
            {
                TurnTheKey();
            }
        }
    }

    bool Openable()
    {
        return (!isOpen && GetComponent<Interactable>().canUse);
    }

    int GetKeyID()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Key>())
        {
            return GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Key>().keyID;
        }
        return 777;
    }

    void TurnTheKey()
    {
        if (lockID == GetKeyID())
        {
            Unlock();
        }
        else
        {
            StayLocked();
        }
    }

    void Unlock()
    {
        isOpen = true;
        if (removeKey) Destroy(GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Key>().gameObject);
        if (removeLock) Destroy(this.gameObject);
        openEvent.Invoke();
    }

    void StayLocked()
    {
        unopenEvent.Invoke();
    }
}