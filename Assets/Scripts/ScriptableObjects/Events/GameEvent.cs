using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The game event scriptable object.
/// </summary>
[CreateAssetMenu(fileName = "Game Event", menuName = "Events/Game Event")]
public class GameEvent : ScriptableObject
{
    private event System.Action _event
        = delegate { };

    /// <summary>
    /// Used to invoke the event.
    /// </summary>
    public void Call()
    {
        this._event();
    }

    // Used to add a function listener to the event.
    public static GameEvent operator+(GameEvent @event, System.Action @func)
    {
        @event._event += @func;
        return @event;
    }

    // Used to remove a function listener from the event.
    public static GameEvent operator-(GameEvent @event, System.Action @func)
    {
        @event._event -= @func;
        return @event;
    }
}
