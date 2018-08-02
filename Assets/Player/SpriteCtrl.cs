using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCtrl : MonoBehaviour
{
	private MovePlayer movePlayer;
	private Animator _animator;

	private void Awake()
	{
		movePlayer = GetComponentInParent<MovePlayer>();
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		MoveDir();
		AnimatePlayer();
	}

	private void MoveDir()
	{
		if (movePlayer.moveDir < 0)
			transform.eulerAngles = new Vector3(0, 0, 0);

		if (movePlayer.moveDir > 0)
			transform.eulerAngles = new Vector3(0, 180, 0);
	}

	private void AnimatePlayer()
	{
		if (movePlayer.moveDir != 0)
		{
			_animator.SetBool("isWalking", true);
		}
		else
		{
			_animator.SetBool("isWalking", false);
		}
	}
}