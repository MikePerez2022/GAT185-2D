using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRayPerception2D : AIPerception2D
{
	[SerializeField] float distance;

	public override GameObject[] GetSensedGameObjects()
	{
		List<GameObject> sensed = new List<GameObject>();

		RaycastHit2D[] raycastHits = Physics2D.RaycastAll(transform.position, transform.forward, distance, layerMask);
		foreach (var raycastHit in raycastHits)
		{
			if (raycastHit.collider.gameObject != null && tagName == "" || raycastHit.collider.CompareTag(tag))
			{
				sensed.Add(raycastHit.collider.gameObject);
			}

		}

		return sensed.ToArray();
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawLine(transform.position, transform.forward * distance);
	}
}
