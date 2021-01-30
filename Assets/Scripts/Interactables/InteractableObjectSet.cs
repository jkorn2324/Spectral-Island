using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains all of the interactable objects that
/// are currently within the game.
/// </summary>
public static class InteractableObjectSet
{

    private static List<InteractableObject> _interactableObjects 
        = new List<InteractableObject>();

    public static void AddInteractableObject(InteractableObject @object)
    {
        _interactableObjects.Add(@object);
    }

    public static void RemoveInteractableObject(InteractableObject @object)
    {
        if(!_interactableObjects.Contains(@object))
        {
            return;
        }
        _interactableObjects.Remove(@object);
    }

    /// <summary>
    /// Gets the closest object to the position.
    /// </summary>
    /// <param name="position">The position.</param>
    /// <returns>An Interactable object.</returns>
    public static InteractableObject GetClosestObjectTo(Vector2 position)
    {
        return null;
    }
}
