using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AICirclePerception2D : AIPerception2D
{
	[SerializeField] float radius = 2;

	public override GameObject[] GetSensedGameObjects()
	{
		List<GameObject> sensed = new List<GameObject>();

		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
		foreach (var collider in colliders)
		{
			if (collider != null && (tagName == "" || collider.gameObject.CompareTag(tagName)))
			{
				sensed.Add(collider.gameObject);
			}
		}

		return sensed.ToArray();
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, radius);
	}

}
