using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CharacterController2D : MonoBehaviour
{
	[SerializeField] LayerMask groundLayerMask;
	[SerializeField] Transform groundCheck;
	[SerializeField] float groundCheckRadius;

	public bool onGround { get; private set; }


	private Vector2 prevPosition;
	private Vector2 position;
	private Vector2 positionOffset;

	private Vector2 velocity;

	private Rigidbody2D rb;
	private CapsuleCollider2D capsuleCollider;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		capsuleCollider = GetComponent<CapsuleCollider2D>();
	}

	private void Update()
	{
		CheckCollision();
	}

	void FixedUpdate()
	{
		prevPosition = rb.position;
		position = prevPosition + positionOffset;
		velocity = (position - positionOffset) / Time.fixedDeltaTime;

		rb.MovePosition(position);
		positionOffset = Vector2.zero;
	}

	public void Move(Vector2 move)
	{
		positionOffset += move;
	}

	public void Teleport(Vector2 newPosition) 
	{
		Vector2 delta = newPosition - position;
		prevPosition += delta;
		position = newPosition;
		rb.MovePosition(position);
	}

	public void CheckCollision()
	{
		onGround = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayerMask);
		foreach (var collider in colliders)
		{
			if (collider.gameObject == gameObject) continue;

			onGround = true;
		}
	}

	public void OnDrawGizmosSelected()
	{
		Gizmos.color = (onGround) ? Color.yellow : Color.red;
		Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
	}
}
