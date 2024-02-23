using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPoints : Spawner
{
	[Header("Points")]
	[SerializeField] Transform[] points;

	public override void Spawn()
	{
		GameObject spawnGameObject = GetSpawnObject();
		Transform spawnTransform = points[Random.Range(0, points.Length)];

		Spawn(spawnGameObject, spawnTransform.position, spawnTransform.rotation);
	}
}
