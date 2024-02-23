using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class Character2D : MonoBehaviour
{
	public enum eFace
	{
		Left,
		Right
	}

	[SerializeField] protected SpriteRenderer spriteRenderer;
	[SerializeField] protected Animator animator;

	[SerializeField, Range(0, 10)] protected float speed = 5;
	[SerializeField, Range(0, 80)] protected float gravity = 60;
	[SerializeField] protected float health = 100;
	[SerializeField] protected eFace spriteFacing = eFace.Right;

	protected CharacterController2D characterController;

	protected Vector2 movement = Vector2.zero;
	protected eFace facing = eFace.Right;


	protected virtual void Start()
	{
		characterController = GetComponent<CharacterController2D>();
	}

	
	protected virtual void FixedUpdate()
	{
		// vertical movement (gravity)
		movement.y -= gravity * Time.fixedDeltaTime;
		movement.y = Mathf.Max(movement.y, -gravity * Time.fixedDeltaTime * 3);

		characterController.Move(movement * Time.fixedDeltaTime);
		UpdateFacing();
	}

	protected void UpdateFacing()
	{
		if (facing == eFace.Left)
		{
			spriteRenderer.flipX = (spriteFacing == eFace.Right);
		}
		else
		{
			spriteRenderer.flipX = !(spriteFacing == eFace.Right);
		}
	}
}
