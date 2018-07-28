using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCtrl : MonoBehaviour
{
	private MovePlayer movePlayer;

	private void Awake()
	{
		movePlayer = GetComponentInParent<MovePlayer>();
	}

	private void Update()
	{
		MoveDir();
	}

	private void MoveDir()
	{
		if (movePlayer.moveDir < 0)
			transform.eulerAngles = new Vector3(0, 0, 0);
		if (movePlayer.moveDir > 0)
			transform.eulerAngles = new Vector3(0, 180, 0);
	}
}