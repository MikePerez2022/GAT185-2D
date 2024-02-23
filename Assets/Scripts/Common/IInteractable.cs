using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
	public abstract void OnInteractStart(GameObject interactor);
	public abstract void OnInteractActive(GameObject interactor);
	public abstract void OnInteractEnd(GameObject interactor);
}
