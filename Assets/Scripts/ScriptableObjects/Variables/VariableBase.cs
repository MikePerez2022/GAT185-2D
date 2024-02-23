using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// VariableBase - ScriptableObject representing a variable of type T.
/// </summary>
public class VariableBase<T> : ScriptableObject, ISerializationCallbackReceiver
{
	public T initialValue;  // The initial value of the variable.

	public T value;  // The current value of the variable.


	/// <summary>
	/// Called after deserialization. Sets the current value to the initial value.
	/// </summary>
	public void OnAfterDeserialize()
	{
		value = initialValue;
	}

	/// <summary>
	/// Called before serialization. Placeholder method with no implementation.
	/// </summary>
	public void OnBeforeSerialize()
	{
		// No implementation needed for this method.
	}

	/// <summary>
	/// Implicit conversion from VariableBase to type T.
	/// Allows using variable directly as if it were of type T.
	/// </summary>
	/// <param name="variable">The variable of type T to convert.</param>
	/// <returns>The underlying value of the variable of type T.</returns>
	public static implicit operator T(VariableBase<T> variable)
	{
		return variable.value;
	}
}
