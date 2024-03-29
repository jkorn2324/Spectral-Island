﻿using System.Collections;
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
        if(_interactableObjects.Count <= 0)
        {
            return null;
        }

        InteractableObject closestObject = _interactableObjects[0];
        float closestDistance = Vector2.Distance(
            position, closestObject.transform.position);
        for(int i = 1; i < _interactableObjects.Count; i++)
        {
            InteractableObject testObject = _interactableObjects[i];
            float dist = Vector2.Distance(
                position, testObject.transform.position);
            if(dist < closestDistance)
            {
                closestObject = testObject;
                closestDistance = dist;
            }
        }
        return closestObject;
    }
}
