using UnityEngine;
using UnityEngine.Events;

public class Carry : MonoBehaviour
{
    public bool isBeingCarried;
    public UnityEvent pickingUpEvent;
    public UnityEvent droppingEvent;

	////private void Update()
	////{
	////	if (Input.GetMouseButtonUp(1))
	////	{
	////		DropItem();
	////	}
	////}

	//private void PickUpItem()
 //   {
	//	Debug.Log("PickUp Item");
	//	//transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
 //       //transform.position = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + (Vector2.up * 0.5f);
 //       //isBeingCarried = true;
 //       //pickingUpEvent.Invoke();
 //   }

 //   private void DropItem()
 //   {
	//	Debug.Log("drop item");
	//	//transform.position = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + (Vector2)GameObject.FindGameObjectWithTag("Player").transform.right;
 //       //transform.parent = null;
	//	//isBeingCarried = false;
 //       //droppingEvent.Invoke();
 //   }

	//public void StartUsingInteractable()
	//{
 //       PickUpItem();
 //       //isBeingCarried = true;
	//}

	//public void StopUsingInteractable()
	//{
    //    DropItem();
    //    //isBeingCarried = false;
    //}
}