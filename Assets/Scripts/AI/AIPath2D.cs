using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPath2D : MonoBehaviour
{
	public enum ePathAction
	{
		Loop,
		PingPong,
		Random
	}

	[SerializeField] private AIPathPoint2D[] points;
	[SerializeField] private ePathAction action = ePathAction.Loop;

	public Vector2 targetPosition => target.transform.position;
	
	AIPathPoint2D target = null;

	private void Start()
	{
		target = points[0];
	}

	public void SetNextPoint()
	{
		// get next index	
		int index = Array.IndexOf(points, target) + 1;
		switch (action)
		{
			case ePathAction.Loop:
				if (index >= points.Length) index = 0;
				break;
			case ePathAction.PingPong:
				break;
			case ePathAction.Random:
				index = UnityEngine.Random.Range(0, points.Length);
				break;
		}

		target = points[index];
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		// check if entered target
		if (collision.gameObject == target.gameObject)
		{
			SetNextPoint();
		}
	}


	public void OnTriggerStay2D(Collider2D collision)
	{
		// check if entered target
		if (collision.gameObject == target.gameObject)
		{
			SetNextPoint();
		}
	}

}