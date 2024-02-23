using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour, IDamagable
{
	[SerializeField] float health = 100;
	[SerializeField] GameObject hitPrefab;
	[SerializeField] GameObject destroyPrefab;

	bool destroyed = false;

	public void ApplyDamage(float damage)
	{
		if (destroyed) return;

		health -= damage;
		if (health <= 0) 
		{
			destroyed = true;
			if (destroyPrefab != null) Instantiate(destroyPrefab, transform.position, Quaternion.identity);

			Destroy(gameObject);
		}
		else
		{
			if (hitPrefab != null) Instantiate(hitPrefab, transform.position, Quaternion.identity);
		}
	}
}
