using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// EventListenerBase - MonoBehaviour that listens to a Scriptable Object event and invokes a UnityEvent<T> in response.
/// </summary>
public class EventListenerBase<T> : MonoBehaviour
{
	[SerializeField] private EventBase<T> _event = default;  // The Scriptable Object event to subscribe to.

	public UnityEvent<T> listener; // The UnityEvent<T> to invoke in response to the Scriptable Object event

	/// <summary>
	/// Subscribe to the Scriptable Object event when this MonoBehaviour is enabled.
	/// </summary>
	private void OnEnable()
	{
		_event?.Subscribe(Respond);
	}

	/// <summary>
	/// Unsubscribe to the Scriptable Object event when this MonoBehaviour is disabled.
	/// </summary>
	private void OnDisable()
	{
		_event?.Unsubscribe(Respond);
	}

	/// <summary>
	/// Response method invoked when the subscribed Scriptable Object event is raised.
	/// Invokes the UnityEvent<T> to trigger the associated Unity events with the provided type T value.
	/// </summary>
	/// <param name="value">The type T value passed by the Scriptable Object event.</param>
	private void Respond(T value)
	{
		listener?.Invoke(value);
	}
}
