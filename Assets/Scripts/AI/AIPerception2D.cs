using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIPerception2D : MonoBehaviour
{
	[SerializeField] protected string tagName;
	[SerializeField] protected LayerMask layerMask = Physics.AllLayers;

	public abstract GameObject[] GetSensedGameObjects();
}
