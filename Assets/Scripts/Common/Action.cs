using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Action - Map Unity Actions (delegates) to methods.
/// </summary>
public class Action : MonoBehaviour
{
	public UnityAction<GameObject> onEnter;
	public UnityAction<GameObject> onStay;
	public UnityAction<GameObject> onExit;
}
