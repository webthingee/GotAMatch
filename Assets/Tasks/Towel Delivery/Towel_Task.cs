using UnityEngine;

public class Towel_Task : MonoBehaviour, ITask
{
    public void TaskComplete()
    {
        Debug.Log("Task Complete: " + GetType());
        
    }
}