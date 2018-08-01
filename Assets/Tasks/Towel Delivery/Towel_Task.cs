using Fungus;
using UnityEngine;

public class Towel_Task : MonoBehaviour, ITask
{
    public int key;
    public IntAct_DeskWorker worker;
    
    public void TaskComplete()
    {
        Debug.Log("Task Complete: " + GetType());
        worker.key = 867;
        worker.lockID = 867;

    }
}