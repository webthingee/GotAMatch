using UnityEngine;

public class Task : MonoBehaviour, ITask
{

    public void TaskComplete()
	{
		Debug.Log("Task Complete");
	}
}