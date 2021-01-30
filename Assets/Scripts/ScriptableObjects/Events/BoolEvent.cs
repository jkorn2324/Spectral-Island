using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Event (Bool)", menuName = "Events/Game Event (Bool)")]
public class BoolEvent : GenericEvent<bool>
{
    public static BoolEvent operator +(BoolEvent @event, System.Action<bool> @func)
    {
        @event._event += @func;
        return @event;
    }

    public static BoolEvent operator -(BoolEvent @event, System.Action<bool> @func)
    {
        @event._event -= @func;
        return @event;
    }
}
