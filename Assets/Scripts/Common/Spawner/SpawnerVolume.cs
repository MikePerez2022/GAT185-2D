using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVolume : Spawner
{
	[Header("Volume")]
	[SerializeField] Collider volume;

	public override void Spawn()
	{
		Vector3 position = transform.position;

		var boxVolume = volume as BoxCollider;
		if (boxVolume != null)
		{
			position.x = Random.Range(boxVolume.bounds.min.x, boxVolume.bounds.max.x);
			position.y = Random.Range(boxVolume.bounds.min.y, boxVolume.bounds.max.y);
			position.z = Random.Range(boxVolume.bounds.min.z, boxVolume.bounds.max.z);
		}

		var sphereVolume = volume as SphereCollider;
		if (sphereVolume != null) 
		{
			position = transform.position + Random.insideUnitSphere * sphereVolume.radius;
		}

		GameObject spawnGameObject = GetSpawnObject();
		Spawn(spawnGameObject, position, transform.rotation);

	}

}
