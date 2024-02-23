using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// EventBase - A simple observer pattern implementation using ScriptableObject.
/// </summary>
public abstract class EventBase<T> : ScriptableObjectBase
{
	// Unity Actions allow you to dynamically call multiple functions.
	// They are a simple way to implement delegates in scripting without
	// needing to explicitly define them.
	public UnityAction<T> onEventRaised;

	/// <summary>
	/// Raises the event with the specified type T value.
	/// </summary>
	/// <param name="value">The type T value to pass to subscribers.</param>
	public void RaiseEvent(T value)
	{
		onEventRaised?.Invoke(value);
	}

	/// <summary>
	/// Subscribes an object to the event.
	/// </summary>
	/// <param name="listener">The object that wants to subscribe.</param>
	public void Subscribe(UnityAction<T> function)
	{
		onEventRaised += function;
	}

	/// <summary>
	/// Unsubscribes an object from the event.
	/// </summary>
	/// <param name="listener">The object that wants to unsubscribe.</param>
	public void Unsubscribe(UnityAction<T> function)
	{
		onEventRaised -= function;
	}
}
