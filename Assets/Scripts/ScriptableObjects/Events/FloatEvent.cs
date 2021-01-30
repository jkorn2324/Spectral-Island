using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Event (Float)", menuName = "Events/Game Event (Float)")]
public class FloatEvent : GenericEvent<float>
{
    public static FloatEvent operator+(FloatEvent @event, System.Action<float> @func)
    {
        @event._event += @func;
        return @event;
    }

    public static FloatEvent operator-(FloatEvent @event, System.Action<float> @func)
    {
        @event._event -= @func;
        return @event;
    }
}
