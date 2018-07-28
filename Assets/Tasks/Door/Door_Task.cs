using UnityEngine;

public class Door_Task : MonoBehaviour, ITask
{
	public void TaskComplete()
	{
		Debug.Log("Task Complete: " + GetType());
		Destroy(this.gameObject);
	}
}