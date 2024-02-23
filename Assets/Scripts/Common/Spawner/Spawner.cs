using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner : MonoBehaviour, IInteractable
{
	[SerializeField] Action action;
	[SerializeField] GameObject[] spawnPrefabs;
	[SerializeField] Transform parentTransform = null;

	[Header("Parameters")]
	[SerializeField] float minSpawnTime = 1;
	[SerializeField] float maxSpawnTime = 1;
	[SerializeField] int maxSpawned = 1;

	[Header("State")]
	[SerializeField] bool enableOnAwake = true;
	[SerializeField] VoidEvent startEvent = null;
	[SerializeField] VoidEvent stopEvent = null;

	private List<GameObject> spawnedList = new List<GameObject>();
	private bool active = false;
	private Coroutine spawnTimerCoroutine;

	public abstract void Spawn();
	
	private void OnEnable()
	{
		startEvent?.Subscribe(SetActive);
	}

	private void OnDisable()
	{
		stopEvent?.Subscribe(SetInactive);
	}

	private void Start()
	{
		active = enableOnAwake;
		if (active)
		{
			SetActive();
		}

		if (action != null)
		{
			action.onEnter += OnInteractStart;
			action.onExit += OnInteractEnd;
			action.onStay += OnInteractActive;
		}
	}

	IEnumerator SpawnTimer(float time)
	{
		while (true)
		{
			yield return new WaitForSeconds(time);
			if (SpawnReady())
			{
				Spawn();
			}
		}
	}
	
	bool SpawnReady()
	{
		return (active && spawnedList.Count < maxSpawned);
	}

	protected void Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
	{
		GameObject go = Instantiate(prefab, position, rotation, parentTransform);
		// track spawned objects
		if (go.TryGetComponent<TrackedObject>(out TrackedObject trackedObject)) 
		{
			trackedObject.OnDestroyed += RemoveSpawn;
			spawnedList.Add(go);
		}
	}

	protected GameObject GetSpawnObject()
	{
		return spawnPrefabs[Random.Range(0, spawnPrefabs.Length)];
	}

	void RemoveSpawn(GameObject go) 
	{
		spawnedList.Remove(go);
	}

	void SetActive() 
	{ 
		active = true;

		if (spawnTimerCoroutine != null)
		{
			StopCoroutine(spawnTimerCoroutine);
			spawnTimerCoroutine = null;
		}
		spawnTimerCoroutine = StartCoroutine(SpawnTimer(Random.Range(minSpawnTime, maxSpawnTime)));
	}

	void SetInactive() 
	{
		active = false;
		
		if (spawnTimerCoroutine != null)
		{
			StopCoroutine(spawnTimerCoroutine);
			spawnTimerCoroutine = null;
		}

	}

	public void OnInteractStart(GameObject gameObject)
	{
		SetActive();
	}

	public void OnInteractActive(GameObject gameObject)
	{
		
	}

	public void OnInteractEnd(GameObject gameObject)
	{
		SetInactive();
	}
}
